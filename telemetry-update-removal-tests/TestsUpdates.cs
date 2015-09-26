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

using System.Collections.Generic;
using NUnit.Framework;

namespace telemetry_update_removal_tests
{
    /// <summary>
    /// Class for tests of functions in telemetry_update_removal.Updates.
    /// </summary>
    [TestFixture]
    public class TestsUpdates
    {
        /// <summary>
        /// checks whether Updates.listHiddenUpdates() works and does not throw
        /// an exception
        /// </summary>
        [Test, Category("NotForAppVeyor")]
        public void Test_listHiddenUpdates()
        {
            List<telemetry_update_removal.UpdateInfo> list
                = telemetry_update_removal.Updates.listHiddenUpdates();
            //list should not be null
            Assert.IsNotNull(list);
            /* We do not know, whether there are hidden updates on the test
             * system, so we cannot really check for non-emptiness of the
             * list. */
            //Assert.IsNotEmpty(list, "Update history is empty!");
        }


        /// <summary>
        /// checks whether Updates.listInstalledUpdates() lists some updates
        /// </summary>
        [Test, Category("NotForAppVeyor")]
        public void Test_listInstalledUpdates()
        {
            List<telemetry_update_removal.UpdateOpInfo> list
                = telemetry_update_removal.Updates.listInstalledUpdates();
            //list should not be null
            Assert.IsNotNull(list);
            //list should contain some elements
            Assert.IsNotEmpty(list, "List of installed updates is empty!");
        }


        /// <summary>
        /// checks whether Updates.listUpdateHistory() list some updates
        /// </summary>
        [Test, Category("NotForAppVeyor")]
        public void Test_listUpdateHistory()
        {
            List<telemetry_update_removal.UpdateOpInfo> list
                = telemetry_update_removal.Updates.listUpdateHistory();
            //list should not be null
            Assert.IsNotNull(list);
            //list should contain some elements
            Assert.IsNotEmpty(list, "Update history is empty!");
        }


        /// <summary>
        /// checks whether Updates.OperationResultCodeToString() returns the
        /// exprected values
        /// </summary>
        [Test]
        public void Test_OperationResultCodeToString()
        {
            Assert.AreEqual("Aborted",
                telemetry_update_removal.Updates.OperationResultCodeToString(
                WUApiLib.OperationResultCode.orcAborted));
            Assert.AreEqual("Failed",
                telemetry_update_removal.Updates.OperationResultCodeToString(
                WUApiLib.OperationResultCode.orcFailed));
            Assert.AreEqual("In progress",
                telemetry_update_removal.Updates.OperationResultCodeToString(
                WUApiLib.OperationResultCode.orcInProgress));
            Assert.AreEqual("Not started",
                telemetry_update_removal.Updates.OperationResultCodeToString(
                WUApiLib.OperationResultCode.orcNotStarted));
            Assert.AreEqual("Succeeded",
                telemetry_update_removal.Updates.OperationResultCodeToString(
                WUApiLib.OperationResultCode.orcSucceeded));
            Assert.AreEqual("Succeeded with errors",
                telemetry_update_removal.Updates.OperationResultCodeToString(
                WUApiLib.OperationResultCode.orcSucceededWithErrors));
        }


        /// <summary>
        /// checks whether Updates.UpdateOperationToString() returns the
        /// expected string values
        /// </summary>
        [Test]
        public void Test_UpdateOperationToString()
        {
            Assert.AreEqual("Installation",
                telemetry_update_removal.Updates.UpdateOperationToString(
                WUApiLib.UpdateOperation.uoInstallation));
            Assert.AreEqual("Uninstallation",
                telemetry_update_removal.Updates.UpdateOperationToString(
                WUApiLib.UpdateOperation.uoUninstallation));
        }
    } //class
} //namespace
