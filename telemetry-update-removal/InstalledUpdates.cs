using System;
using System.Collections.Generic;

namespace telemetry_update_removal
{
    public class InstalledUpdates
    {
        /// <summary>
        /// internal cache that lists the currently installed Microsoft updates
        /// </summary>
        private List<Updates.UpdateOpInfo> m_InstalledCache;

        /// <summary>
        /// default constructor
        /// </summary>
        public InstalledUpdates()
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
                m_InstalledCache = Updates.listInstalledUpdates();
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
        public bool isInstalledByKBNumber(uint KB)
        {
            //Make sure we have an update cache for the search.
            generateCache();

            string search = "KB" + KB.ToString();
            int searchLen = search.Length;

            foreach (var item in m_InstalledCache)
            {
                int pos = item.title.IndexOf(search);
                if (pos >= 0)
                {
                    //might be a match
                    int titleLen = item.title.Length;
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
                        if (!Char.IsDigit(item.title[pos + searchLen]))
                            return true;
                    } //if there is more text
                } //if position is valid
            } //foreach
            return false;
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
