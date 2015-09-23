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
using WUApiLib;

namespace telemetry_update_removal
{
    /// <summary>
    /// aux. structure to hold information about an update operation
    /// </summary>
    public class UpdateOpInfo
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
        /// time of the (un-)installation; seems to be UTC and not local time
        /// </summary>
        public DateTime date;

        /// <summary>
        /// the type of update operation - install or uninstall
        /// </summary>
        public UpdateOperation operation;

        /// <summary>
        /// result code of the update
        /// </summary>
        public OperationResultCode result;

        /// <summary>
        /// default constructor: initializes all members
        /// </summary>
        public UpdateOpInfo()
        {
            title = "";
            ID = "";
            date = DateTime.MinValue;
            operation = UpdateOperation.uoUninstallation;
            result = OperationResultCode.orcNotStarted;
        }
    } //class
} //namespace
