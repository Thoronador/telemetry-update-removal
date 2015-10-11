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
using System.Xml;

namespace telemetry_update_removal
{
    /// <summary>
    /// Class that can read a KBInfo collection from an XML file.
    /// </summary>
    public class KBInfoReader
    {   
        /// <summary>
        /// tries to read KBInfo elements from an XML file
        /// </summary>
        /// <param name="filename">path of the XML file</param>
        /// <param name="data">collection that will be used to save the elements that were read from the XML file</param>
        /// <returns>Returns true, if the read operation was successful.
        /// Returns false, if the read operation failed.</returns>
        public static bool readFromFile(string filename, ref List<KBInfo> data)
        {
            //Null, empty or whitespace strings are not a valid file name.
            if (String.IsNullOrWhiteSpace(filename))
                return false;
            //File has to exist, because we want to read from it.
            if (!System.IO.File.Exists(filename))
                return false;

            data = new List<KBInfo>();

            XmlReader reader = null;
            try
            {
                reader = XmlReader.Create(new System.IO.StreamReader(filename, System.Text.Encoding.UTF8, false));
            }
            catch (Exception)
            {
                //Something bad happened here. Time to exit.
                return false;
            }

            System.Xml.Serialization.XmlSerializer serKB = new System.Xml.Serialization.XmlSerializer(typeof(KBInfo));
            try
            {
                reader.ReadStartElement("updates");
            }
            catch (Exception)
            {
                reader.Close();
                reader = null;
                return false;
            }
            while (reader.Read())
            {
                if ((reader.Name == "kb") && (reader.NodeType == XmlNodeType.Element))
                {
                    object obj = serKB.Deserialize(reader);
                    if (obj.GetType() == typeof(KBInfo))
                    {
                        data.Add((KBInfo)obj);
                    }
                    else
                    {
                        //wrong object type
                        reader.Close();
                        reader = null;
                        obj = null;
                        return false;
                    } //else
                } //if <kb ....>
                else if (reader.Name == "updates" && reader.NodeType == XmlNodeType.EndElement)
                {
                    break;
                }
                else
                {
                    return false;
                }
            } //while
            //read the end element
            bool success = false;
            try
            {
                reader.ReadEndElement();
                success = true;
            }
            catch
            {
                success = false;
            }
            reader.Close();
            reader = null;
            return success;
        }
    } //class
} //namespace
