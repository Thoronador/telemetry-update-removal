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
            dgvUpdates.Rows.Clear();
            foreach (var item in instUpd)
            {
                dgvUpdates.Rows.Add(new string[] {item.date.ToString(),
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
            dgvUpdates.Rows.Clear();
            foreach (var item in instUpd)
            {
                dgvUpdates.Rows.Add(new string[] { item.date.ToString(),
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


        /// <summary>
        /// filters the shown update entries by their title - only updates
        /// whose titles contain the given string will be shown
        /// </summary>
        /// <param name="filter">the filter text</param>
        private void filterUpdatesByTitle(string filter)
        {
            int i = 0;
            //Intercept empty values.
            if (String.IsNullOrWhiteSpace(filter))
            {
                //Filter is empty, so let's show all updates.
                for (i = 0; i < dgvUpdates.Rows.Count; ++i)
                {
                    dgvUpdates.Rows[i].Visible = true;
                } //for
                return;
            }//if filter is empty

            const int idxTitle = 3;
            string lcFilter = filter.ToLower();
            for (i = 0; i < dgvUpdates.Rows.Count; ++i)
            {
                dgvUpdates.Rows[i].Visible = dgvUpdates.Rows[i].Cells[idxTitle].Value.ToString().ToLower().Contains(lcFilter);
            } //for
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            tbFilterByTitle.Text = "";
        }

        private void tbFilterByTitle_TextChanged(object sender, EventArgs e)
        {
            btnClearFilter.Enabled = ("" != tbFilterByTitle.Text);
            filterUpdatesByTitle(tbFilterByTitle.Text);
        }
    } //class
} //namespace
