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
    /// <summary>
    /// Provides some basic functionality to list installed updates and/or the
    /// complete update history for all Microsoft updates on the current
    /// machine.
    /// </summary>
    public class Updates
    {
        /// <summary>
        /// returns a human-readable string to describe the passed
        /// UpdateOperation value (e.g. "Installation" or "Uninstallation",
        /// depending on what the value indicates)
        /// </summary>
        /// <param name="value">UpdateOperation value that shall be represented
        /// as string</param>
        /// <returns>string that describes the update operation</returns>
        public static string UpdateOperationToString(UpdateOperation value)
        {
            switch (value)
            {
                case UpdateOperation.uoInstallation:
                    return "Installation";
                case UpdateOperation.uoUninstallation:
                    return "Uninstallation";
                default:
                    return "unknown operation";
            } //switch
        }


        /// <summary>
        /// returns a human-readable string to describe the passed
        /// OperationResultCode value (e.g. "Succeeded", "Failed", etc.,
        /// depending on whether the code indicates success, failure or any
        /// other update result)
        /// </summary>
        /// <param name="orc">WUApiLib.OperationResultCode value</param>
        /// <returns>string that describes the operation result code value</returns>
        public static string OperationResultCodeToString(OperationResultCode orc)
        {
            switch (orc)
            {
                case OperationResultCode.orcAborted:
                    return "Aborted";
                case OperationResultCode.orcFailed:
                    return "Failed";
                case OperationResultCode.orcInProgress:
                    return "In progress";
                case OperationResultCode.orcNotStarted:
                    return "Not started";
                case OperationResultCode.orcSucceeded:
                    return "Succeeded";
                case OperationResultCode.orcSucceededWithErrors:
                    return "Succeeded with errors";
                default:
                    return "unknown";
            } //swi
        }
        

        /// <summary>
        /// lists the update history
        /// </summary>
        /// <returns>returns the applied updates as list of UpdateOpInfo structures</returns>
        public static List<UpdateOpInfo> listUpdateHistory()
        {
            UpdateSession session = new UpdateSession();
            IUpdateSearcher updateSearcher = session.CreateUpdateSearcher();
            int count = updateSearcher.GetTotalHistoryCount();
            var history = updateSearcher.QueryHistory(0, count);

            List<UpdateOpInfo> result = new List<UpdateOpInfo>();
            for (int i = 0; i < count; ++i)
            {
                UpdateOpInfo opInfo = new UpdateOpInfo();
                /* Note: The Date value seems to be in UTC and not in local
                 * time, because this value was off by a few hours. */
                opInfo.date = history[i].Date;
                opInfo.ID = history[i].UpdateIdentity.UpdateID;
                opInfo.operation = history[i].Operation;
                opInfo.result = history[i].ResultCode;
                opInfo.title = history[i].Title;
                
                result.Add(opInfo);
            } //for

            history = null;
            updateSearcher = null;
            session = null;
            return result;
        }


        /// <summary>
        /// checks whether an entry of the update history is a successful
        /// installation operation
        /// </summary>
        /// <param name="uhe">an update history entry</param>
        /// <returns>Returns true, if the entry marks a successful installation.</returns>
        private static bool isInstallSuccess(IUpdateHistoryEntry uhe)
        {
            if (uhe == null)
                return false;
            if (uhe.Operation == UpdateOperation.uoInstallation)
            {
                return (uhe.ResultCode == OperationResultCode.orcSucceeded
                    || uhe.ResultCode == OperationResultCode.orcSucceededWithErrors);
            }
            return false;
        }


        /// <summary>
        /// checks whether an entry of the update history is a successful
        /// uninstallation operation
        /// </summary>
        /// <param name="uhe">an update history entry</param>
        /// <returns>Returns true, if the entry marks a successful uninstallation.</returns>
        private static bool isUninstallSuccess(IUpdateHistoryEntry uhe)
        {
            if (uhe == null)
                return false;
            if (uhe.Operation == UpdateOperation.uoUninstallation)
            {
                return (uhe.ResultCode == OperationResultCode.orcSucceeded
                    || uhe.ResultCode == OperationResultCode.orcSucceededWithErrors);
            }
            return false;
        }


        /// <summary>
        /// lists the installed updates (still experimental)
        /// </summary>
        /// <returns>returns a list of installed updates</returns>
        public static List<UpdateOpInfo> listInstalledUpdates()
        {
            UpdateSession session = new UpdateSession();
            IUpdateSearcher updateSearcher = session.CreateUpdateSearcher();
            int count = updateSearcher.GetTotalHistoryCount();
            IUpdateHistoryEntryCollection foundUpdates = updateSearcher.QueryHistory(0, count);

            HashSet<UpdateOpInfo> set = new HashSet<UpdateOpInfo>();
            for (int i = 0; i < count; ++i)
            {
                var upd = foundUpdates[i];

                UpdateOpInfo ud = new UpdateOpInfo();
                ud.title = upd.Title;
                ud.ID = upd.UpdateIdentity.UpdateID;
                /* Note: The Date value seems to be in UTC and not in local
                 * time, because this value was off by a few hours. */
                ud.date = upd.Date;
                ud.operation = upd.Operation;
                ud.result = upd.ResultCode;

                //Check whether we have to add or remove the update.
                if (isInstallSuccess(upd))
                    set.Add(ud);
                else if (isUninstallSuccess(upd))
                    set.Remove(ud);
                upd = null;
                ud = null;
            } //for

            foundUpdates = null;
            updateSearcher = null;
            session = null;

            List<UpdateOpInfo> result = new List<UpdateOpInfo>();
            foreach (var item in set)
            {
                result.Add(item);
            }
            set = null;
            return result;
        }
    } //class
} //namespace
