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
using System.Diagnostics;
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


        /// <summary>
        /// lists updates that are hidden on the local machine
        /// </summary>
        /// <returns>Returns a list of hidden updates, if any.</returns>
        public static List<UpdateInfo> listHiddenUpdates()
        {
            UpdateSession session = new UpdateSession();
            IUpdateSearcher updateSearcher = session.CreateUpdateSearcher();
            //Do not go online to search for updates. We want to be fast(er).
            updateSearcher.Online = false;

            var searchResult = updateSearcher.Search("IsHidden=1");
            int count = searchResult.Updates.Count;
            List<UpdateInfo> result = new List<UpdateInfo>();
            for (int i = 0; i < count; ++i)
            {
                UpdateInfo info = new UpdateInfo();

                info.ID = searchResult.Updates[i].Identity.UpdateID;
                info.title = searchResult.Updates[i].Title;
                info.minDownloadSize = searchResult.Updates[i].MinDownloadSize;
                info.maxDownloadSize = searchResult.Updates[i].MaxDownloadSize;
                info.uninstallable = searchResult.Updates[i].IsUninstallable;
                info.securityBulletins.Clear();
                if (searchResult.Updates[i].SecurityBulletinIDs != null)
                {
                    foreach (var item in searchResult.Updates[i].SecurityBulletinIDs)
                    {
                        info.securityBulletins.Add(item.ToString());
                    } //foreach
                } //if
                info.KBArticleIDs.Clear();

                if (null != searchResult.Updates[i].KBArticleIDs)
                {
                    foreach (var item in searchResult.Updates[i].KBArticleIDs)
                    {
                        info.KBArticleIDs.Add(item.ToString());
                    } //foreach
                } //if

                result.Add(info);
            } //for

            searchResult = null;
            updateSearcher = null;
            session = null;
            return result;
        }


        /// <summary>
        /// tries to uninstall an update (identified by KB number)
        /// </summary>
        /// <param name="KB">Knowlege Base Article ID of the update that shall be removed</param>
        /// <returns>Returns true, if the update was removed successfully.
        /// Returns false, if the update could not be installed.</returns>
        public static bool uninstallByKB(uint KB)
        {
            //General pattern: wusa.exe /kb:12345678 /uninstall /quiet /norestart
            ProcessStartInfo startInfo = new ProcessStartInfo("wusa.exe");
            startInfo.Arguments = "/kb:" + KB.ToString() + " /uninstall /quiet /norestart";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process proc = new Process();
            proc.StartInfo = startInfo;
            //Start the process.
            if (!proc.Start())
                return false;
            //Wait until process exits - might take a long time!
            proc.WaitForExit();
            //Success is usually indicated by ExitCode zero.
            return (proc.ExitCode == 0);
        }
    } //class
} //namespace
