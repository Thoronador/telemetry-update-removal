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
        /// checks whether Updates.listInstalledUpdates() lists some updates
        /// </summary>
        [Test]
        public void Test_listInstalledUpdates()
        {
            List<telemetry_update_removal.Updates.UpdateOpInfo> list
                = telemetry_update_removal.Updates.listInstalledUpdates();
            //list should not be null
            Assert.IsNotNull(list);
            //list should contain some elements
            Assert.IsNotEmpty(list, "List of installed updates is empty!");
        }


        /// <summary>
        /// checks whether Updates.listUpdateHistory() list some updates
        /// </summary>
        [Test]
        public void Test_listUpdateHistory()
        {
            List<telemetry_update_removal.Updates.UpdateOpInfo> list
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
        public void TestFault()
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
