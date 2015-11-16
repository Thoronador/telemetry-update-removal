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

using NUnit.Framework;

namespace telemetry_update_removal_tests
{
    /// <summary>
    /// Class that contains tests for the InstalledUpdatesHistory class.
    /// </summary>
    [TestFixture]
    public class TestsInstalledUpdatesHistory
    {
        [Test]
        public void Test_clearCache()
        {
            /* Inconclusive, because the cache is a private variable and cannot
             * be checked directly. */
            Assert.Inconclusive("Cannot test InstalledUpdatesHistory.clearCache() yet.");
        }


        /// <summary>
        /// checks whether InstalledUpdates.getInstalledIDByKB() delivers the
        /// proper update IDs
        /// </summary>
        [Test, Category("NotForAppVeyor")]
        public void Test_getInstalledIDByKB()
        {
            telemetry_update_removal.InstalledUpdatesHistory instUpd = new telemetry_update_removal.InstalledUpdatesHistory();

            //There is no KB ID zero, so there should be no ID for that.
            Assert.IsNull(instUpd.getInstalledIDByKB(0));

            //There is no KB ID 308, so there should be no ID for that.
            Assert.IsNull(instUpd.getInstalledIDByKB(308));

            /* The following KB IDs are part of MS15-097, a security update of
             * the September 2015 patchday, so it should usually be installed
             * on up-to-date systems.
             *
             * - KB3087135 is for Windows Vista and Windows Server 2008.
             * - KB3087039 is for Windows 7, Windows 8, Windows Server 2008 R2
             *   and Windows Server 2012.
             * - KB3081455 should do the same for Windows 10.
             */
            string ID_3087135 = instUpd.getInstalledIDByKB(3087135);
            string ID_3087039 = instUpd.getInstalledIDByKB(3087039);
            string ID_3081455 = instUpd.getInstalledIDByKB(3081455);

            //One of the IDs should not be null.
            Assert.IsTrue(ID_3081455 != null || ID_3087039 != null || ID_3087135 != null);

            instUpd = null;
        }


        /// <summary>
        /// Checks whether InstalledUpdates.isInstalledByID() works as expected.
        /// </summary>
        [Test, Category("NotForAppVeyor")]
        public void Test_isInstalledByID()
        {
            telemetry_update_removal.InstalledUpdatesHistory instUpd = new telemetry_update_removal.InstalledUpdatesHistory();

            //There is no empty ID, so there should be no installed update for that.
            Assert.IsFalse(instUpd.isInstalledByID(""));

            /* The following KB IDs are part of MS15-097, a security update of
             * the September 2015 patchday, so it should usually be installed
             * on up-to-date systems.
             *
             * - KB3087135 is for Windows Vista and Windows Server 2008.
             * - KB3087039 is for Windows 7, Windows 8, Windows Server 2008 R2
             *   and Windows Server 2012.
             * - KB3081455 should do the same for Windows 10.
             */

            string ID_3087135 = instUpd.getInstalledIDByKB(3087135);
            string ID_3087039 = instUpd.getInstalledIDByKB(3087039);
            string ID_3081455 = instUpd.getInstalledIDByKB(3081455);

            //One of the IDs should not be null.
            Assert.IsTrue(ID_3081455 != null || ID_3087039 != null || ID_3087135 != null);

            //... and one of the updates should be installed.
            Assert.IsTrue(instUpd.isInstalledByID(ID_3087135)
                || instUpd.isInstalledByID(ID_3087039)
                || instUpd.isInstalledByID(ID_3081455));
            instUpd = null;
        }


        /// <summary>
        /// Checks whether isInstalledByKBNumber() works as expected.
        /// </summary>
        [Test, Category("NotForAppVeyor")]
        public void Test_isInstalledByKBNumber()
        {
            telemetry_update_removal.InstalledUpdatesHistory instUpd = new telemetry_update_removal.InstalledUpdatesHistory();

            //There is no KB ID zero, so there should be no installed update for that.
            Assert.IsFalse(instUpd.isInstalledByKBNumber(0));

            //There is no KB ID 308, so there should be no installed update for that.
            Assert.IsFalse(instUpd.isInstalledByKBNumber(308));

            /* The following KB IDs are part of MS15-097, a security update of
             * the September 2015 patchday, so it should usually be installed
             * on up-to-date systems.
             *
             * - KB3087135 is for Windows Vista and Windows Server 2008.
             * - KB3087039 is for Windows 7, Windows 8, Windows Server 2008 R2
             *   and Windows Server 2012.
             * - KB3081455 should do the same for Windows 10.
             */
            Assert.IsTrue(instUpd.isInstalledByKBNumber(3087135)
                || instUpd.isInstalledByKBNumber(3087039)
                || instUpd.isInstalledByKBNumber(3081455));
            instUpd = null;
        }
    } //class
} //namespace
