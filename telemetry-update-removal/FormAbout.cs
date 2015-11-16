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

using System.Reflection;
using System.Windows.Forms;

namespace telemetry_update_removal
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();

            //set data according to values in assembly
            // ---- title
            object attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(
                typeof(AssemblyTitleAttribute), true);
            lblTitle.Text = "About " + ((AssemblyTitleAttribute[])attributes)[0].Title;
            // ---- description
            attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(
                typeof(AssemblyDescriptionAttribute), true);
            lblDescription.Text = ((AssemblyDescriptionAttribute[])attributes)[0].Description;
            // ---- version
            lblVersion.Text = "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            // ---- copyright: AssemblyCopyrightAttribute
            attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(
                typeof(AssemblyCopyrightAttribute), true);
            lblCopyright.Text = ((AssemblyCopyrightAttribute[])attributes)[0].Copyright;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FormAbout_Resize(object sender, System.EventArgs e)
        {
            int newX = (this.Width - btnClose.Width) / 2;
            if (newX > 0 && newX != btnClose.Location.X)
                btnClose.Location = new System.Drawing.Point(newX, btnClose.Location.Y);
        }
    }
}
