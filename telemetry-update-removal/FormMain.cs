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
using System.Windows.Forms;

namespace telemetry_update_removal
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// list of problematic updates
        /// </summary>
        private List<KBInfo> m_dataKB;

        /// <summary>
        /// constant that indicates the column index for the "Installed"
        /// column of the telemetry updates data grid view
        /// </summary>
        private const int idxInstalled = 2;

        /// <summary>
        /// constant that indicates the column index for the "Blocked"
        /// column of the telemetry updates data grid view
        /// </summary>
        private const int idxBlocked = 3;

        public FormMain()
        {
            InitializeComponent();
            //Show version in title bar.
            this.Text += " v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            m_dataKB = new List<KBInfo>();
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


        /// <summary>
        /// Disables the buttons that can be used to reload the update list.
        /// This can be used while a reload of the list is in progress to avoid
        /// that the user accidentally clicks the button more than once and
        /// thus triggers more than one reload request, which would take longer
        /// than necessary.
        /// </summary>
        private void disableListActionButtons()
        {
            btnListInstalled.Enabled = false;
            btnListCompleteHistory.Enabled = false;
            btnListHiddenUpdates.Enabled = false;
            btnListTelemetryUpdates.Enabled = false;
        }


        /// <summary>
        /// Re-enables the buttons that can be used to reload the update list.
        /// Use this after call to disableListActionButtons() as soon as the
        /// reload process is finished. Otherwise the user will not be able to
        /// reload the update list again.
        /// </summary>
        private void enableListActionButtons()
        {
            btnListInstalled.Enabled = true;
            btnListCompleteHistory.Enabled = true;
            btnListHiddenUpdates.Enabled = true;
            btnListTelemetryUpdates.Enabled = true;
        }


        /// <summary>
        /// Resets the background colour of both "list updates" buttons to the
        /// default that they had when the application started.
        /// </summary>
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

        private void btnListHiddenUpdates_Click(object sender, EventArgs e)
        {
            btnListHiddenUpdates.BackColor = System.Drawing.SystemColors.Control;
            disableListActionButtons();
            btnListHiddenUpdates.BackColor = System.Drawing.Color.Yellow;
            var hiddenUpdates = Updates.listHiddenUpdates();
            dgvHiddenUpdates.Rows.Clear();
            foreach (var item in hiddenUpdates)
            {
                //Prepare string that contains all KB numbers.
                string KBs = "";
                foreach (var kb in item.KBArticleIDs)
                {
                    KBs += ", " + kb;
                } //foreach (inner)
                if (KBs.StartsWith(", "))
                    KBs = KBs.Remove(0, 2);
                if (String.IsNullOrWhiteSpace(KBs))
                    KBs = "none";
                //Prepare string that contains all bulletin IDs.
                string bulletins = "";
                foreach (var secBulletin in item.securityBulletins)
                {
                    bulletins += ", " + secBulletin;
                } //foreach (inner)
                if (bulletins.StartsWith(", "))
                    bulletins = bulletins.Remove(0, 2);
                if (String.IsNullOrWhiteSpace(bulletins))
                    bulletins = "none";
                //Add new row to data grid view.
                dgvHiddenUpdates.Rows.Add(new string[] {item.title, item.ID,
                    KBs, bulletins });
            } //foreach
            if (hiddenUpdates.Count == 0)
            {
                //Show a row that indicates that there are no hidden updates.
                dgvHiddenUpdates.Rows.Add(new string[] {"None", "N/A",
                    "N/A", "N/A" });
            } //if
            hiddenUpdates = null;
            btnListHiddenUpdates.BackColor = System.Drawing.Color.LightGreen;
            enableListActionButtons();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (!KBInfoReader.readFromFile("updatelist.xml", ref m_dataKB))
            {
                MessageBox.Show("The list of problematic KB updates could not be loaded!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvTelemetryUpdates.Rows.Clear();
            foreach (KBInfo item in m_dataKB)
            {
                int rowIndex = dgvTelemetryUpdates.Rows.Add(new string[] {
                    item.KB.ToString(), item.title.ToString(), "?", "?"});
                dgvTelemetryUpdates.Rows[rowIndex].Cells[idxInstalled].Style.BackColor = System.Drawing.Color.Yellow;
                dgvTelemetryUpdates.Rows[rowIndex].Cells[idxBlocked].Style.BackColor = System.Drawing.Color.Yellow;
            } //foreach
            int i = 0;
            for (i = 0; i < dgvTelemetryUpdates.Columns.Count; i++)
            {
                dgvTelemetryUpdates.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            } //for
        }

        private void btnListTelemetryUpdates_Click(object sender, EventArgs e)
        {
            disableListActionButtons();
            InstalledUpdates instUpdates = new InstalledUpdates();
            
            int i = 0;
            for (i = 0; i < m_dataKB.Count; ++i)
            {
                if (instUpdates.isInstalledByKBNumber(m_dataKB[i].KB))
                    dgvTelemetryUpdates.Rows[i].Cells[idxInstalled].Style.BackColor = System.Drawing.Color.LightSalmon;
                else
                    dgvTelemetryUpdates.Rows[i].Cells[idxInstalled].Style.BackColor = System.Drawing.Color.LightGreen;
            } //for
            instUpdates = null;
            enableListActionButtons();
        }
    } //class
} //namespace
