using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RunSQL_CMD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string sSQLFilePath = string.Empty;
            if (txtFilePath.Text.Length > 0)
            {
                sSQLFilePath = txtFilePath.Text;
                if (txtInstanceName.Text.Length > 0)
                {
                    string sInstanceName = txtInstanceName.Text;
                    if (Path.GetExtension(sSQLFilePath).ToLower() == ".sql")
                    {
                        string sCommand = "/C sqlcmd -S " + sInstanceName.Trim() + " -i \"" + sSQLFilePath + "\"";
                        System.Diagnostics.Process.Start("CMD.exe", sCommand);
                    }
                    else
                        MessageBox.Show("Only SQL files can be run, please choose a valid SQL file.");
                }
                else
                    MessageBox.Show("Please enter a valid instance name.");
            }
            else
                MessageBox.Show("Please choose a file.");
        }
    }
}
