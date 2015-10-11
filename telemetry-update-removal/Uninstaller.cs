/*
    This file is part of the Windows 7/8 telemetry update removal tool.
    Copyright (C) 2015  Thoronador

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using WUApiLib;

namespace telemetry_update_removal
{
    public class Uninstaller
    {
        public Uninstaller()
        {
            m_Busy = false;
        }

        private static bool containsKB(StringCollection coll, HashSet<uint> numbersKB)
        {
            if (coll == null || null == numbersKB)
                return false;
            if (coll.Count <= 0 || numbersKB.Count <= 0)
                return false;
            int i;
            
            for (i = 0; i < coll.Count; ++i)
            {
                HashSet<uint>.Enumerator iter = numbersKB.GetEnumerator();
                while (iter.MoveNext())
                {
                    if (!String.IsNullOrWhiteSpace(coll[i]) && coll[i] == iter.Current.ToString())
                        return true;
                } //while
            } //for i
            return false;
        }


        /// <summary>
        /// uninstall and hide the updates that match the given KB numbers
        /// </summary>
        /// <param name="numbersKB">knowledge base (KB) article numbers</param>
        /// <returns>Returns true, if uinstallation was successful.
        /// Returns false, if uninstallation failed.</returns>
        public bool uninstallAndHide(HashSet<uint> numbersKB)
        {
            if (null == numbersKB)
                return false;
            if (numbersKB.Count <= 0)
                return false;
            if (m_Busy)
                return false;

            m_Busy = true;
            UpdateSession session = new UpdateSession();

            IUpdateSearcher updateSearcher = session.CreateUpdateSearcher();
            //Do not go online to search for updates. We want to be fast(er).
            updateSearcher.Online = false;

            UpdateSearchCompleteCallback callback = new UpdateSearchCompleteCallback();

            var searchJob = updateSearcher.BeginSearch("IsInstalled=1 or IsInstalled=0", callback, null);

            while (!searchJob.IsCompleted)
            {
                //Process application events.
                System.Windows.Forms.Application.DoEvents();
                System.Threading.Thread.Sleep(0);
            } //while

            var searchResult = updateSearcher.EndSearch(searchJob);
            int count = searchResult.Updates.Count;

            List<IUpdate> toBeRemoved = new List<IUpdate>();

            int i = 0;
            for (i = 0; i < count; ++i)
            {
                if (containsKB(searchResult.Updates[i].KBArticleIDs, numbersKB))
                {
                    /* Hide update from future installations. This way we avoid
                     * that the update might get installed again by an
                     * automatic update. */
                    searchResult.Updates[i].IsHidden = true;
                    // If update is installed, but can be uninstalled, add it to the list.
                    if (searchResult.Updates[i].IsInstalled && searchResult.Updates[i].IsUninstallable)
                    {
                        toBeRemoved.Add(searchResult.Updates[i]);
                    } //if installed
                } //if KB matches
            } //for


            try
            {
                searchJob.RequestAbort();
                searchJob.CleanUp();
            }
            catch (Exception)
            {
                // Do nothing.
            }
            searchJob = null;
            searchResult = null;

            updateSearcher = null;
            session = null;

            //Finish, if there is nothing more to do.
            if (toBeRemoved.Count <= 0)
            {
                m_Busy = false;
                return true;
            }

            UpdateCollection collection = new UpdateCollection();
            foreach (var item in toBeRemoved)
            {
                collection.Add(item);
            }

            bool reboot = false;
            bool success = Updates.uninstallUpdates(collection, ref reboot);
            m_Busy = false;
            return success;
        }


        /// <summary>
        /// indicates whether this instance is already occupied by an uninstall job
        /// </summary>
        private bool m_Busy;
    } //class
} //namespace
