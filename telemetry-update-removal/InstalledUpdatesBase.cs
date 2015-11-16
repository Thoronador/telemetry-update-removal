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

namespace telemetry_update_removal
{
    /// <summary>
    /// Abstract base class for all classes that provide functions to check
    /// whether a certain update is installed.
    /// </summary>
    abstract public class InstalledUpdatesBase
    {
        /// <summary>
        /// checks whether a certain update is installed, using the knowledge
        /// base ("KB") number
        /// </summary>
        /// <param name="KB">the knowledge base number</param>
        /// <returns>Returns true, if the update with the given KB is installed.
        /// Returns false, if the update is not installed.</returns>
        abstract public bool isInstalledByKBNumber(uint KB);


        /// <summary>
        /// checks whether an update title contains a KB number
        /// </summary>
        /// <param name="title">full title of the update</param>
        /// <param name="KB">knowledge base number</param>
        /// <returns>Returns true, if the title contains the KB number.
        /// Returns false otherwise.</returns>
        public static bool titleMatchesKB(string title, uint KB)
        {
            if (string.IsNullOrWhiteSpace(title))
                return false;

            string search = "KB" + KB.ToString();
            int searchLen = search.Length;
            int pos = title.IndexOf(search);
            if (pos >= 0)
            {
                //might be a match
                int titleLen = title.Length;
                if (pos + searchLen >= titleLen)
                    //KB number is last part of title, i.e. we got the update
                    return true;
                //Is there more text?
                if (pos + searchLen < titleLen)
                {
                    /* If the next character is not a digit, then we found
                     * the exact KB number here. Otherwise it is another KB
                     * number, because there are more digits.
                     * This check is necessary to avoid false positives,
                     * because otherwise we would return true (update found)
                     * for "KB4321", although the string says "KB43215".
                     */
                    if (!Char.IsDigit(title[pos + searchLen]))
                        return true;
                } //if there is more text
            } //if position is valid
            return false;
        }
    } //class
} //namespace
