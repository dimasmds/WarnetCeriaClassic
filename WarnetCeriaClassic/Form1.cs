using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WarnetCeriaClassic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {

        }

        private void doLogin(string NamaPaket)
        {
            var prior = Form.ActiveForm;
            using (var dlg = new MainForm(){ Nama = NamaTextBox.Text, Paket = NamaPaket })
            {
                dlg.StartPosition = FormStartPosition.Manual;
                dlg.FormClosing += delegate { prior.Show(); };
                prior.Hide();
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    // do something like warnet do;
                    // such as
                    // close all programs
                    // hide desktop with dolphin legend wallpaper *LOL
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NamaTextBox.Text))
                MessageBox.Show("Nama di isi gan");
            else
                doLogin("Standard");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NamaTextBox.Text))
                MessageBox.Show("Nama di isi gan");
            else
                doLogin("Game 1");
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NamaTextBox.Text))
                MessageBox.Show("Nama di isi gan");
            else
                doLogin("Hemat");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NamaTextBox.Text))
                MessageBox.Show("Nama di isi gan");
            else
                doLogin("Game 2");
        }
    }
}
