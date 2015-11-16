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
using System.Management;

namespace telemetry_update_removal
{
    /// <summary>
    /// Provides functions to check whether a certain update is installed.
    /// This variant uses WMIC to check for updates.
    /// </summary>
    public class InstalledUpdatesWMIC : InstalledUpdatesBase
    {
        /// <summary>
        /// internal cache that lists the currently installed Microsoft updates
        /// </summary>
        private List<uint> m_InstalledCache;


        /// <summary>
        /// default constructor
        /// </summary>
        public InstalledUpdatesWMIC()
        {
            //Set cache to null and create it just on demand.
            m_InstalledCache = null;
        }


        // <summary>
        /// creates the internal update cache, if it is not present yet
        /// </summary>
        private void generateCache()
        {
            if (null == m_InstalledCache)
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT Description, HotFixID FROM Win32_QuickFixEngineering");
                ManagementObjectCollection coll = mos.Get();

                List<uint> kbIDs = new List<uint>();
                foreach (var item in coll)
                {
                    if (item["HotFixID"] != null)
                    {
                        string kb = System.Convert.ToString(item["HotFixID"]);
                        if (kb.StartsWith("KB"))
                        {
                            kb = kb.Remove(0, 2).Trim();
                            try
                            {
                                kbIDs.Add(System.Convert.ToUInt32(kb));
                            }
                            catch (System.Exception)
                            {
                                //conversion failed, go on with next object
                            }
                        } //if
                    } //if
                } //foreach
                kbIDs.Sort();
                m_InstalledCache = kbIDs;
            } //if
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
            generateCache();
            return m_InstalledCache.Contains(KB);
        }
    } //class
} //namespace
