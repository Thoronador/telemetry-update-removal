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

namespace telemetry_update_removal
{
    /// <summary>
    /// aux. structure to hold information about an update
    /// </summary>
    public class UpdateInfo
    {
        /// <summary>
        /// title of the update
        /// </summary>
        public string title;

        /// <summary>
        /// internal ID / GUID of the update
        /// </summary>
        public string ID;

        /// <summary>
        /// minimum download size of the update, unit is not known
        /// </summary>
        public Decimal minDownloadSize;

        /// <summary>
        /// minimum download size of the update, unit is not known
        /// </summary>
        public Decimal maxDownloadSize;

        /// <summary>
        /// whether or not the update is uninstallable
        /// </summary>
        public bool uninstallable;

        /// <summary>
        /// security bulletins that relate to the update
        /// </summary>
        public List<string> securityBulletins;

        /// <summary>
        /// list of Knowledge Base articles for that update
        /// </summary>
        public List<string> KBArticleIDs;

        /// <summary>
        /// default constructor: initializes all members
        /// </summary>
        public UpdateInfo()
        {
            title = "";
            ID = "";
            minDownloadSize = 0;
            maxDownloadSize = 0;
            uninstallable = false;
            securityBulletins = new List<string>();
            KBArticleIDs = new List<string>();
        }
    } //class
} //namespace
