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
        public struct UpdateOpInfo
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
        } //struct
        

        /// <summary>
        /// list update history
        /// </summary>
        /// <returns>returns the applied updates as list of strings with date and title of update</returns>
        public static List<string> listUpdateHistory()
        {
            UpdateSession session = new UpdateSession();
            IUpdateSearcher updateSearcher = session.CreateUpdateSearcher();
            int count = updateSearcher.GetTotalHistoryCount();
            var history = updateSearcher.QueryHistory(0, count);

            List<string> result = new List<string>();
            for (int i = 0; i < count; ++i)
                result.Add(history[i].Date.ToString() + " - " + history[i].Title);

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
