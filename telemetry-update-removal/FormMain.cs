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
