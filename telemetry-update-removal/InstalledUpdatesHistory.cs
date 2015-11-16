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

using System.Collections.Generic;

namespace telemetry_update_removal
{
    /// <summary>
    /// Provides functions to check whether a certain update is installed.
    /// This variant uses the WUApiLib's update history to check for installed
    /// updates.
    /// </summary>
    public class InstalledUpdatesHistory: InstalledUpdatesBase
    {
        /// <summary>
        /// internal cache that lists the currently installed Microsoft updates
        /// </summary>
        private List<UpdateOpInfo> m_InstalledCache;

        /// <summary>
        /// default constructor
        /// </summary>
        public InstalledUpdatesHistory()
        {
            //Set cache to null and create it just on demand.
            m_InstalledCache = null;
        }


        /// <summary>
        /// creates the internal update cache, if it is not present yet
        /// </summary>
        private void generateCache()
        {
            if (null == m_InstalledCache)
                m_InstalledCache = Updates.listInstalledUpdatesFromHistory();
        }


        /// <summary>
        /// checks whether a certain update is installed
        /// </summary>
        /// <param name="ID">ID of the update (usually a GUID)</param>
        /// <returns>Returns true, if the update is installed.
        /// Returns false, if the update is not installed.</returns>
        public bool isInstalledByID(string ID)
        {
            //Make sure we have an update cache for the search.
            generateCache();

            foreach (var item in m_InstalledCache)
            {
                if (item.ID == ID)
                    return true;
            } //foreach
            return false;
        }


        /// <summary>
        /// checks whether a certain update is installed, using the knowledge
        /// base ("KB") number
        /// </summary>
        /// <param name="KB">the knowledge base number</param>
        /// <returns>Returns true, if the update with the given KB is installed.
        /// Returns false, if the update is not installed.</returns>
        override public bool isInstalledByKBNumber(uint KB)
        {
            //Make sure we have an update cache for the search.
            generateCache();

            foreach (var item in m_InstalledCache)
            {
                if (titleMatchesKB(item.title, KB))
                    return true;
            } //foreach
            return false;
        }


        /// <summary>
        /// finds the ID / GUID of an installed update
        /// </summary>
        /// <param name="KB">the knowledge base number of the update</param>
        /// <returns>Returns a string containing the update's ID.
        /// Returns null, if the update was not found/is not installed.</returns>
        public string getInstalledIDByKB(uint KB)
        {
            //Make sure we have an update cache for the search.
            generateCache();

            foreach (var item in m_InstalledCache)
            {
                if (titleMatchesKB(item.title, KB))
                    return item.ID;
            } //foreach
            return null;
        }


        /// <summary>
        /// Clears the internal cache of installed updates. Use this, if you
        /// have reason to believe that at least one update was installed or
        /// uninstalled since the cache was created. The cache gets created
        /// whenever isInstalledByID() or isInstalledByKBNumber() is called and
        /// there is no cache yet.
        /// 
        /// Calling this functions will cause a cache regeneration during the
        /// next call to isInstalledByID() or isInstalledByKBNumber().
        /// Therefore, the next call of one of these functions will take a bit
        /// longer.
        /// </summary>
        public void clearCache()
        {
            m_InstalledCache = null;
        }
    } //class
} //namespace
