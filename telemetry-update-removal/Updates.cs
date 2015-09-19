using System;
using System.Collections.Generic;
using WUApiLib;

namespace telemetry_update_removal
{
    public class Updates
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
            /// time of the (un-)installation
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
        } //struct


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
        /// lists the installed updates (still experimental)
        /// </summary>
        /// <returns>returns a list of installed updates</returns>
        public static List<UpdateOpInfo> listInstalledUpdates()
        {
            UpdateSession session = new UpdateSession();
            IUpdateSearcher updateSearcher = session.CreateUpdateSearcher();
            int count = updateSearcher.GetTotalHistoryCount();
            IUpdateHistoryEntryCollection foundUpdates = updateSearcher.QueryHistory(0, count);

            List<UpdateOpInfo> result = new List<UpdateOpInfo>();
            for (int i = 0; i < count; ++i)
            {
                var upd = foundUpdates[i];
                if (upd.Operation == UpdateOperation.uoInstallation && upd.ResultCode == OperationResultCode.orcSucceeded)
                {
                    UpdateOpInfo ud = new UpdateOpInfo();
                    ud.title = upd.Title;
                    ud.ID = upd.UpdateIdentity.UpdateID;
                    ud.date = upd.Date;
                    ud.operation = upd.Operation;
                    ud.result = upd.ResultCode;
                    result.Add(ud);
                } //if
                upd = null;
            } //for

            foundUpdates = null;
            updateSearcher = null;
            session = null;

            return result;
        }
    } //class
} //namespace
