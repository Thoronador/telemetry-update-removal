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
using System.Windows.Forms;

namespace telemetry_update_removal
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnListInstalled_Click(object sender, EventArgs e)
        {
            resetButtonColours();
            disableListActionButtons();
            btnListInstalled.BackColor = System.Drawing.Color.Yellow;
            var instUpd = Updates.listInstalledUpdates();
            dataGridView1.Rows.Clear();
            foreach (var item in instUpd)
            {
                dataGridView1.Rows.Add(new string[] {item.date.ToString(),
                    Updates.UpdateOperationToString(item.operation),
                    Updates.OperationResultCodeToString(item.result),
                    item.title, item.ID });
            }
            instUpd = null;
            btnListInstalled.BackColor = System.Drawing.Color.LightGreen;
            enableListActionButtons();
        }

        private void btnListCompleteHistory_Click(object sender, EventArgs e)
        {
            resetButtonColours();
            disableListActionButtons();
            btnListCompleteHistory.BackColor = System.Drawing.Color.Yellow;
            var instUpd = Updates.listUpdateHistory();
            dataGridView1.Rows.Clear();
            foreach (var item in instUpd)
            {
                dataGridView1.Rows.Add(new string[] { item.date.ToString(),
                    Updates.UpdateOperationToString(item.operation),
                    Updates.OperationResultCodeToString(item.result),
                    item.title, item.ID });
            }
            instUpd = null;
            btnListCompleteHistory.BackColor = System.Drawing.Color.LightGreen;
            enableListActionButtons();
        }

        private void disableListActionButtons()
        {
            btnListInstalled.Enabled = false;
            btnListCompleteHistory.Enabled = false;
        }

        private void enableListActionButtons()
        {
            btnListInstalled.Enabled = true;
            btnListCompleteHistory.Enabled = true;
        }

        private void resetButtonColours()
        {
            btnListInstalled.BackColor = System.Drawing.SystemColors.Control;
            btnListCompleteHistory.BackColor = System.Drawing.SystemColors.Control;
        }
    } //class
} //namespace
