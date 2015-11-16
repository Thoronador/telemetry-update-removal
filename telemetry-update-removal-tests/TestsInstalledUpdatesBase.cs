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
    /// Class that contains tests for the InstalledUpdatesBase class.
    /// </summary>
    [TestFixture]
    public class TestsInstalledUpdatesBase
    {
        /// <summary>
        /// checks whether InstalledUpdatesBase.titleMatchesKB() works as expected
        /// </summary>
        [Test]
        public void Test_titleMatchesKB()
        {
            //Positive return values:
            Assert.IsTrue(telemetry_update_removal.InstalledUpdatesBase.titleMatchesKB(
                "Windows-Tool zum Entfernen bösartiger Software - Dezember 2014 (KB890830)",
                890830));
            Assert.IsTrue(telemetry_update_removal.InstalledUpdatesBase.titleMatchesKB(
                "Definition Update for Windows Defender - KB915597 (Definition 1.199.1468.0)",
                915597));
            Assert.IsTrue(telemetry_update_removal.InstalledUpdatesBase.titleMatchesKB(
                "Update für Windows Vista (KB3020338)", 3020338));

            //Negative return values:
            Assert.IsFalse(telemetry_update_removal.InstalledUpdatesBase.titleMatchesKB(
                "Update für Windows Vista (KB3020338)", 3020));
            Assert.IsFalse(telemetry_update_removal.InstalledUpdatesBase.titleMatchesKB(
                "Update für Windows Vista (KB3020338)", 30203));
            Assert.IsFalse(telemetry_update_removal.InstalledUpdatesBase.titleMatchesKB(
                "Update für Windows Vista (KB3020338)", 302033));
            Assert.IsFalse(telemetry_update_removal.InstalledUpdatesBase.titleMatchesKB(
                "Update für Windows Vista (3020338)", 3020338));
            Assert.IsFalse(telemetry_update_removal.InstalledUpdatesBase.titleMatchesKB(
                "There is no KB ID here", 12345));

            //null, empty, whitespace tests
            Assert.IsFalse(telemetry_update_removal.InstalledUpdatesBase.titleMatchesKB(
                null, 1234));
            Assert.IsFalse(telemetry_update_removal.InstalledUpdatesBase.titleMatchesKB(
                "", 1234));
            Assert.IsFalse(telemetry_update_removal.InstalledUpdatesBase.titleMatchesKB(
                "     \t \r\n \v  ", 1234));
        }
    } //class
} //namespace
