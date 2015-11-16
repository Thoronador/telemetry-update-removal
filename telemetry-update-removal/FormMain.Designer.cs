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
            this.dgvHiddenUpdates = new System.Windows.Forms.DataGridView();
            this.colHiddenTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHiddenID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHiddenKB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHiddenBulletin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTelemetryUpdates = new System.Windows.Forms.TabPage();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.lblTelemetryUpdates = new System.Windows.Forms.Label();
            this.dgvTelemetryUpdates = new System.Windows.Forms.DataGridView();
            this.colTelemetryKB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelemetryTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelemetryInstalled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelemetryBlocked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnListTelemetryUpdates = new System.Windows.Forms.Button();
            this.tabPageInstalledHistory = new System.Windows.Forms.TabPage();
            this.tabPageHiddenUpdates = new System.Windows.Forms.TabPage();
            this.btnListHiddenUpdates = new System.Windows.Forms.Button();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.tsslMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarMain = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDetectionMethod = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWMIC = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdateHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAboutMenuList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHiddenUpdates)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageTelemetryUpdates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelemetryUpdates)).BeginInit();
            this.tabPageInstalledHistory.SuspendLayout();
            this.tabPageHiddenUpdates.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnListInstalled
            // 
            this.btnListInstalled.AutoSize = true;
            this.btnListInstalled.Location = new System.Drawing.Point(6, 6);
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
            this.dgvUpdates.Location = new System.Drawing.Point(3, 61);
            this.dgvUpdates.Name = "dgvUpdates";
            this.dgvUpdates.ReadOnly = true;
            this.dgvUpdates.RowHeadersVisible = false;
            this.dgvUpdates.Size = new System.Drawing.Size(557, 341);
            this.dgvUpdates.TabIndex = 2;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 55;
            // 
            // colOperation
            // 
            this.colOperation.HeaderText = "Operation";
            this.colOperation.Name = "colOperation";
            this.colOperation.ReadOnly = true;
            this.colOperation.Width = 78;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 62;
            // 
            // colTitle
            // 
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            this.colTitle.Width = 52;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 43;
            // 
            // btnListCompleteHistory
            // 
            this.btnListCompleteHistory.Location = new System.Drawing.Point(191, 6);
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
            this.lblFilterbyTitle.Location = new System.Drawing.Point(6, 38);
            this.lblFilterbyTitle.Name = "lblFilterbyTitle";
            this.lblFilterbyTitle.Size = new System.Drawing.Size(65, 13);
            this.lblFilterbyTitle.TabIndex = 4;
            this.lblFilterbyTitle.Text = "Filter by title:";
            // 
            // tbFilterByTitle
            // 
            this.tbFilterByTitle.Location = new System.Drawing.Point(85, 35);
            this.tbFilterByTitle.Name = "tbFilterByTitle";
            this.tbFilterByTitle.Size = new System.Drawing.Size(291, 20);
            this.tbFilterByTitle.TabIndex = 5;
            this.tbFilterByTitle.TextChanged += new System.EventHandler(this.tbFilterByTitle_TextChanged);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Enabled = false;
            this.btnClearFilter.Location = new System.Drawing.Point(382, 33);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(75, 23);
            this.btnClearFilter.TabIndex = 6;
            this.btnClearFilter.Text = "Clear filter";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // dgvHiddenUpdates
            // 
            this.dgvHiddenUpdates.AllowUserToAddRows = false;
            this.dgvHiddenUpdates.AllowUserToDeleteRows = false;
            this.dgvHiddenUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHiddenUpdates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvHiddenUpdates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHiddenUpdates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHiddenTitle,
            this.colHiddenID,
            this.colHiddenKB,
            this.colHiddenBulletin});
            this.dgvHiddenUpdates.Location = new System.Drawing.Point(6, 35);
            this.dgvHiddenUpdates.Name = "dgvHiddenUpdates";
            this.dgvHiddenUpdates.ReadOnly = true;
            this.dgvHiddenUpdates.RowHeadersVisible = false;
            this.dgvHiddenUpdates.Size = new System.Drawing.Size(554, 367);
            this.dgvHiddenUpdates.TabIndex = 7;
            // 
            // colHiddenTitle
            // 
            this.colHiddenTitle.HeaderText = "Title";
            this.colHiddenTitle.Name = "colHiddenTitle";
            this.colHiddenTitle.ReadOnly = true;
            this.colHiddenTitle.Width = 52;
            // 
            // colHiddenID
            // 
            this.colHiddenID.HeaderText = "ID";
            this.colHiddenID.Name = "colHiddenID";
            this.colHiddenID.ReadOnly = true;
            this.colHiddenID.Width = 43;
            // 
            // colHiddenKB
            // 
            this.colHiddenKB.HeaderText = "KB Article(s)";
            this.colHiddenKB.Name = "colHiddenKB";
            this.colHiddenKB.ReadOnly = true;
            this.colHiddenKB.Width = 89;
            // 
            // colHiddenBulletin
            // 
            this.colHiddenBulletin.HeaderText = "Bulletin(s)";
            this.colHiddenBulletin.Name = "colHiddenBulletin";
            this.colHiddenBulletin.ReadOnly = true;
            this.colHiddenBulletin.Width = 77;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageTelemetryUpdates);
            this.tabControl1.Controls.Add(this.tabPageInstalledHistory);
            this.tabControl1.Controls.Add(this.tabPageHiddenUpdates);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(598, 428);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPageTelemetryUpdates
            // 
            this.tabPageTelemetryUpdates.Controls.Add(this.btnUninstall);
            this.tabPageTelemetryUpdates.Controls.Add(this.lblTelemetryUpdates);
            this.tabPageTelemetryUpdates.Controls.Add(this.dgvTelemetryUpdates);
            this.tabPageTelemetryUpdates.Controls.Add(this.btnListTelemetryUpdates);
            this.tabPageTelemetryUpdates.Location = new System.Drawing.Point(4, 22);
            this.tabPageTelemetryUpdates.Name = "tabPageTelemetryUpdates";
            this.tabPageTelemetryUpdates.Size = new System.Drawing.Size(590, 402);
            this.tabPageTelemetryUpdates.TabIndex = 2;
            this.tabPageTelemetryUpdates.Text = "Telemetry updates";
            this.tabPageTelemetryUpdates.UseVisualStyleBackColor = true;
            // 
            // btnUninstall
            // 
            this.btnUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUninstall.Enabled = false;
            this.btnUninstall.Location = new System.Drawing.Point(474, 376);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(113, 23);
            this.btnUninstall.TabIndex = 4;
            this.btnUninstall.Text = "Uninstall and hide";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // lblTelemetryUpdates
            // 
            this.lblTelemetryUpdates.AutoSize = true;
            this.lblTelemetryUpdates.Location = new System.Drawing.Point(6, 6);
            this.lblTelemetryUpdates.Name = "lblTelemetryUpdates";
            this.lblTelemetryUpdates.Size = new System.Drawing.Size(97, 13);
            this.lblTelemetryUpdates.TabIndex = 2;
            this.lblTelemetryUpdates.Text = "Telemetry updates:";
            // 
            // dgvTelemetryUpdates
            // 
            this.dgvTelemetryUpdates.AllowUserToAddRows = false;
            this.dgvTelemetryUpdates.AllowUserToDeleteRows = false;
            this.dgvTelemetryUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTelemetryUpdates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTelemetryUpdates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTelemetryUpdates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTelemetryKB,
            this.colTelemetryTitle,
            this.colTelemetryInstalled,
            this.colTelemetryBlocked});
            this.dgvTelemetryUpdates.Location = new System.Drawing.Point(3, 22);
            this.dgvTelemetryUpdates.Name = "dgvTelemetryUpdates";
            this.dgvTelemetryUpdates.ReadOnly = true;
            this.dgvTelemetryUpdates.RowHeadersVisible = false;
            this.dgvTelemetryUpdates.Size = new System.Drawing.Size(584, 348);
            this.dgvTelemetryUpdates.TabIndex = 1;
            // 
            // colTelemetryKB
            // 
            this.colTelemetryKB.HeaderText = "KB";
            this.colTelemetryKB.Name = "colTelemetryKB";
            this.colTelemetryKB.ReadOnly = true;
            this.colTelemetryKB.Width = 46;
            // 
            // colTelemetryTitle
            // 
            this.colTelemetryTitle.HeaderText = "Title";
            this.colTelemetryTitle.Name = "colTelemetryTitle";
            this.colTelemetryTitle.ReadOnly = true;
            this.colTelemetryTitle.Width = 52;
            // 
            // colTelemetryInstalled
            // 
            this.colTelemetryInstalled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTelemetryInstalled.HeaderText = "Installed";
            this.colTelemetryInstalled.MinimumWidth = 25;
            this.colTelemetryInstalled.Name = "colTelemetryInstalled";
            this.colTelemetryInstalled.ReadOnly = true;
            this.colTelemetryInstalled.Width = 71;
            // 
            // colTelemetryBlocked
            // 
            this.colTelemetryBlocked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colTelemetryBlocked.HeaderText = "Blocked";
            this.colTelemetryBlocked.Name = "colTelemetryBlocked";
            this.colTelemetryBlocked.ReadOnly = true;
            this.colTelemetryBlocked.Width = 71;
            // 
            // btnListTelemetryUpdates
            // 
            this.btnListTelemetryUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnListTelemetryUpdates.Location = new System.Drawing.Point(3, 376);
            this.btnListTelemetryUpdates.Name = "btnListTelemetryUpdates";
            this.btnListTelemetryUpdates.Size = new System.Drawing.Size(174, 23);
            this.btnListTelemetryUpdates.TabIndex = 0;
            this.btnListTelemetryUpdates.Text = "List installed telemetry updates";
            this.btnListTelemetryUpdates.UseVisualStyleBackColor = true;
            this.btnListTelemetryUpdates.Click += new System.EventHandler(this.btnListTelemetryUpdates_Click);
            // 
            // tabPageInstalledHistory
            // 
            this.tabPageInstalledHistory.Controls.Add(this.btnListInstalled);
            this.tabPageInstalledHistory.Controls.Add(this.dgvUpdates);
            this.tabPageInstalledHistory.Controls.Add(this.btnClearFilter);
            this.tabPageInstalledHistory.Controls.Add(this.btnListCompleteHistory);
            this.tabPageInstalledHistory.Controls.Add(this.tbFilterByTitle);
            this.tabPageInstalledHistory.Controls.Add(this.lblFilterbyTitle);
            this.tabPageInstalledHistory.Location = new System.Drawing.Point(4, 22);
            this.tabPageInstalledHistory.Name = "tabPageInstalledHistory";
            this.tabPageInstalledHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInstalledHistory.Size = new System.Drawing.Size(566, 336);
            this.tabPageInstalledHistory.TabIndex = 0;
            this.tabPageInstalledHistory.Text = "Installed / History";
            this.tabPageInstalledHistory.UseVisualStyleBackColor = true;
            // 
            // tabPageHiddenUpdates
            // 
            this.tabPageHiddenUpdates.Controls.Add(this.btnListHiddenUpdates);
            this.tabPageHiddenUpdates.Controls.Add(this.dgvHiddenUpdates);
            this.tabPageHiddenUpdates.Location = new System.Drawing.Point(4, 22);
            this.tabPageHiddenUpdates.Name = "tabPageHiddenUpdates";
            this.tabPageHiddenUpdates.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHiddenUpdates.Size = new System.Drawing.Size(566, 336);
            this.tabPageHiddenUpdates.TabIndex = 1;
            this.tabPageHiddenUpdates.Text = "Hidden updates";
            this.tabPageHiddenUpdates.UseVisualStyleBackColor = true;
            // 
            // btnListHiddenUpdates
            // 
            this.btnListHiddenUpdates.Location = new System.Drawing.Point(6, 6);
            this.btnListHiddenUpdates.Name = "btnListHiddenUpdates";
            this.btnListHiddenUpdates.Size = new System.Drawing.Size(176, 23);
            this.btnListHiddenUpdates.TabIndex = 8;
            this.btnListHiddenUpdates.Text = "List hidden updates (SLOW!)";
            this.btnListHiddenUpdates.UseVisualStyleBackColor = true;
            this.btnListHiddenUpdates.Click += new System.EventHandler(this.btnListHiddenUpdates_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslMain,
            this.toolStripProgressBarMain});
            this.statusStripMain.Location = new System.Drawing.Point(0, 458);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(598, 22);
            this.statusStripMain.TabIndex = 9;
            // 
            // tsslMain
            // 
            this.tsslMain.Name = "tsslMain";
            this.tsslMain.Size = new System.Drawing.Size(70, 17);
            this.tsslMain.Text = "Status: None";
            // 
            // toolStripProgressBarMain
            // 
            this.toolStripProgressBarMain.Name = "toolStripProgressBarMain";
            this.toolStripProgressBarMain.Size = new System.Drawing.Size(200, 16);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiProgram,
            this.tsmiDetectionMethod,
            this.tsmiAboutMenuList});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(598, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiProgram
            // 
            this.tsmiProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
            this.tsmiProgram.Name = "tsmiProgram";
            this.tsmiProgram.Size = new System.Drawing.Size(59, 20);
            this.tsmiProgram.Text = "Program";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(152, 22);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiDetectionMethod
            // 
            this.tsmiDetectionMethod.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiWMIC,
            this.tsmiUpdateHistory});
            this.tsmiDetectionMethod.Name = "tsmiDetectionMethod";
            this.tsmiDetectionMethod.Size = new System.Drawing.Size(104, 20);
            this.tsmiDetectionMethod.Text = "Detection method";
            // 
            // tsmiWMIC
            // 
            this.tsmiWMIC.Checked = true;
            this.tsmiWMIC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiWMIC.Name = "tsmiWMIC";
            this.tsmiWMIC.Size = new System.Drawing.Size(297, 22);
            this.tsmiWMIC.Text = "WMIC (slower, but more precise)";
            this.tsmiWMIC.Click += new System.EventHandler(this.tsmiWMIC_Click);
            // 
            // tsmiUpdateHistory
            // 
            this.tsmiUpdateHistory.Name = "tsmiUpdateHistory";
            this.tsmiUpdateHistory.Size = new System.Drawing.Size(297, 22);
            this.tsmiUpdateHistory.Text = "Update history (faster, but might be incorrect)";
            this.tsmiUpdateHistory.Click += new System.EventHandler(this.tsmiUpdateHistory_Click);
            // 
            // tsmiAboutMenuList
            // 
            this.tsmiAboutMenuList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.tsmiAboutMenuList.Name = "tsmiAboutMenuList";
            this.tsmiAboutMenuList.Size = new System.Drawing.Size(48, 20);
            this.tsmiAboutMenuList.Text = "About";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(152, 22);
            this.tsmiAbout.Text = "About";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 480);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(400, 220);
            this.Name = "FormMain";
            this.Text = "Telemetry update removal";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHiddenUpdates)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageTelemetryUpdates.ResumeLayout(false);
            this.tabPageTelemetryUpdates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelemetryUpdates)).EndInit();
            this.tabPageInstalledHistory.ResumeLayout(false);
            this.tabPageInstalledHistory.PerformLayout();
            this.tabPageHiddenUpdates.ResumeLayout(false);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.DataGridView dgvHiddenUpdates;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHiddenTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHiddenID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHiddenKB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHiddenBulletin;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageInstalledHistory;
        private System.Windows.Forms.TabPage tabPageHiddenUpdates;
        private System.Windows.Forms.Button btnListHiddenUpdates;
        private System.Windows.Forms.TabPage tabPageTelemetryUpdates;
        private System.Windows.Forms.Button btnListTelemetryUpdates;
        private System.Windows.Forms.Label lblTelemetryUpdates;
        private System.Windows.Forms.DataGridView dgvTelemetryUpdates;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelemetryKB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelemetryTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelemetryInstalled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelemetryBlocked;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel tsslMain;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarMain;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiProgram;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiDetectionMethod;
        private System.Windows.Forms.ToolStripMenuItem tsmiWMIC;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdateHistory;
        private System.Windows.Forms.ToolStripMenuItem tsmiAboutMenuList;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
    }
}

