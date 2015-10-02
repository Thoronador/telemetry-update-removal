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
using System.Collections.Generic;

namespace telemetry_update_removal_tests
{
    /// <summary>
    /// Class that contains tests for the KBInfoReader class.
    /// </summary>
    [TestFixture]
    public class TestsKBInfoReader
    {
        /// <summary>
        /// Tests whether readFromFile() can read the default XML file (updatelist.xml)
        /// which is provided with the binary executable.
        /// </summary>
        [Test]
        public void Test_readFromFile()
        {
            List<telemetry_update_removal.KBInfo> theData = new List<telemetry_update_removal.KBInfo>();
            bool success = telemetry_update_removal.KBInfoReader.readFromFile("updatelist.xml", ref theData);
            //Read operation should be successful.
            Assert.IsTrue(success);
            //Data should contain some elements
            Assert.IsTrue(theData.Count > 0);
        }
    } //class
} //namespace
