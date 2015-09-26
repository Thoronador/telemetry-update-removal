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

namespace telemetry_update_removal
{
    /// <summary>
    /// Class that holds information about a knowledge base article.
    /// </summary>
    public class KBInfo
    {
        /// <summary>
        /// Number of the Knowledge Base article
        /// </summary>
        public uint KB;


        /// <summary>
        /// short title of the update
        /// </summary>
        public string title;


        /// <summary>
        /// summary/description of the update
        /// </summary>
        public string summary;


        /// <summary>
        /// default constructor
        /// </summary>
        public KBInfo()
        {
            KB = 0;
            title = "";
            summary = "";
        }
    } //class
} //namespace
