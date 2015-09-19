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

namespace telemetry_update_removal
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnListInstalled = new System.Windows.Forms.Button();
            this.dgvUpdates = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnListCompleteHistory = new System.Windows.Forms.Button();
            this.lblFilterbyTitle = new System.Windows.Forms.Label();
            this.tbFilterByTitle = new System.Windows.Forms.TextBox();
            this.btnClearFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdates)).BeginInit();
            this.SuspendLayout();
            // 
            // btnListInstalled
            // 
            this.btnListInstalled.AutoSize = true;
            this.btnListInstalled.Location = new System.Drawing.Point(12, 12);
            this.btnListInstalled.Name = "btnListInstalled";
            this.btnListInstalled.Size = new System.Drawing.Size(179, 23);
            this.btnListInstalled.TabIndex = 0;
            this.btnListInstalled.Text = "List installed updates from history";
            this.btnListInstalled.UseVisualStyleBackColor = true;
            this.btnListInstalled.Click += new System.EventHandler(this.btnListInstalled_Click);
            // 
            // dgvUpdates
            // 
            this.dgvUpdates.AllowUserToAddRows = false;
            this.dgvUpdates.AllowUserToDeleteRows = false;
            this.dgvUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUpdates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvUpdates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpdates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colOperation,
            this.colStatus,
            this.colTitle,
            this.colID});
            this.dgvUpdates.Location = new System.Drawing.Point(12, 67);
            this.dgvUpdates.Name = "dgvUpdates";
            this.dgvUpdates.RowHeadersVisible = false;
            this.dgvUpdates.Size = new System.Drawing.Size(590, 354);
            this.dgvUpdates.TabIndex = 2;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Width = 55;
            // 
            // colOperation
            // 
            this.colOperation.HeaderText = "Operation";
            this.colOperation.Name = "colOperation";
            this.colOperation.Width = 78;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 62;
            // 
            // colTitle
            // 
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Width = 52;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Width = 43;
            // 
            // btnListCompleteHistory
            // 
            this.btnListCompleteHistory.Location = new System.Drawing.Point(197, 12);
            this.btnListCompleteHistory.Name = "btnListCompleteHistory";
            this.btnListCompleteHistory.Size = new System.Drawing.Size(185, 23);
            this.btnListCompleteHistory.TabIndex = 3;
            this.btnListCompleteHistory.Text = "List complete update history";
            this.btnListCompleteHistory.UseVisualStyleBackColor = true;
            this.btnListCompleteHistory.Click += new System.EventHandler(this.btnListCompleteHistory_Click);
            // 
            // lblFilterbyTitle
            // 
            this.lblFilterbyTitle.AutoSize = true;
            this.lblFilterbyTitle.Location = new System.Drawing.Point(12, 44);
            this.lblFilterbyTitle.Name = "lblFilterbyTitle";
            this.lblFilterbyTitle.Size = new System.Drawing.Size(65, 13);
            this.lblFilterbyTitle.TabIndex = 4;
            this.lblFilterbyTitle.Text = "Filter by title:";
            // 
            // tbFilterByTitle
            // 
            this.tbFilterByTitle.Location = new System.Drawing.Point(91, 41);
            this.tbFilterByTitle.Name = "tbFilterByTitle";
            this.tbFilterByTitle.Size = new System.Drawing.Size(291, 20);
            this.tbFilterByTitle.TabIndex = 5;
            this.tbFilterByTitle.TextChanged += new System.EventHandler(this.tbFilterByTitle_TextChanged);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Enabled = false;
            this.btnClearFilter.Location = new System.Drawing.Point(388, 39);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(75, 23);
            this.btnClearFilter.TabIndex = 6;
            this.btnClearFilter.Text = "Clear filter";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 433);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.tbFilterByTitle);
            this.Controls.Add(this.lblFilterbyTitle);
            this.Controls.Add(this.btnListCompleteHistory);
            this.Controls.Add(this.dgvUpdates);
            this.Controls.Add(this.btnListInstalled);
            this.MinimumSize = new System.Drawing.Size(400, 150);
            this.Name = "FormMain";
            this.Text = "Telemetry update removal";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListInstalled;
        private System.Windows.Forms.DataGridView dgvUpdates;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.Button btnListCompleteHistory;
        private System.Windows.Forms.Label lblFilterbyTitle;
        private System.Windows.Forms.TextBox tbFilterByTitle;
        private System.Windows.Forms.Button btnClearFilter;
    }
}

