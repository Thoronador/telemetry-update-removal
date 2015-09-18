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

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Text = "Installiert...";
            var instUpd = Updates.listInstalledUpdates();
            dataGridView1.Rows.Clear();
            foreach (var item in instUpd)
            {
                dataGridView1.Rows.Add(new string[] {item.date.ToString(), item.title, item.ID });
            }
            button1.Text = "button1";
            button1.Enabled = true;
        }
    }
}
