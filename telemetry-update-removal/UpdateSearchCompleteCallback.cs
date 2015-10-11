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

using WUApiLib;

namespace telemetry_update_removal
{
    /// <summary>
    /// Class that implements the ISearchCompletedCallback interface of WUApiLib.
    /// </summary>
    public class UpdateSearchCompleteCallback : ISearchCompletedCallback
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public UpdateSearchCompleteCallback()
        {
            m_called = false;
        }
        

        public void Invoke(ISearchJob searchJob, ISearchCompletedCallbackArgs callbackArgs)
        {
            //Update is completed!
            m_called = true;
        }


        /// <summary>
        /// Checks whether the callback has been called yet.
        /// </summary>
        /// <returns>Returns true, if the Invoke() method has been called at least once.</returns>
        public bool called()
        {
            return m_called;
        }

        private bool m_called;
    } //class
} //namespace
