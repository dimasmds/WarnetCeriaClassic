using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WarnetCeriaClassic
{
    public partial class MainForm : Form
    {
        public string Nama { get; set; }
        public string Paket { get; set; }

        private Stopwatch _myStopwatch = new Stopwatch();
        private Timer _myTimer = new Timer();
        

        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width/2)-70, 0);
            _myTimer.Interval = 1000;
            _myTimer.Tick += _myTimer_Tick;
            _myTimer.Start();
            _myStopwatch.Start();
            NamaLabel.Text = "Nama: " + Nama;
            PaketLabel.Text = "Paket: " + Paket;
        }

        private void _myTimer_Tick(object sender, EventArgs e)
        {
            string hour = _myStopwatch.Elapsed.Hours < 10 ? "0" + _myStopwatch.Elapsed.Hours.ToString() : _myStopwatch.Elapsed.Hours.ToString();
            string minute = _myStopwatch.Elapsed.Minutes < 10 ? "0" + _myStopwatch.Elapsed.Minutes.ToString() : _myStopwatch.Elapsed.Minutes.ToString();
            string second = _myStopwatch.Elapsed.Seconds < 10 ? "0" + _myStopwatch.Elapsed.Seconds.ToString() : _myStopwatch.Elapsed.Seconds.ToString();
            string time = hour + ":" + minute + ":" + second;
            TimeLabel.Text = time;
            labelHarga.Text = "Total harga: " + hitungHarga(_myStopwatch.Elapsed.Hours, _myStopwatch.Elapsed.Minutes).ToString();
        }

        private decimal hitungHarga(int hours, int minutes)
        {
            if (Paket == "Hemat")
                return (9000 * (hours + 5) / 5);
            else if (Paket == "Game 1")
                return (5000 * (hours + 2) / 2);
            else if (Paket == "Game 2")
                return (9000 * (hours + 4) / 4);
            else
            {
                if (minutes > 30)
                {
                    return (2000 * hours) + 1000;
                }
                else
                    return 2000 * hours;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jumlah tagihan anda sebesar Rp." + hitungHarga(_myStopwatch.Elapsed.Hours, _myStopwatch.Elapsed.Minutes).ToString());
        }

        private void ClientSizeAnimation(int max, int min)
        {
            if (this.Height < max)
            {
                while (this.Height < max)
                {
                    this.Height++;
                    Application.DoEvents();
                }
            }
            else
            {
                while (this.Height > min)
                {
                    this.Height--;
                    Application.DoEvents();
                }
            }

        }

        private void MainForm_DoubleClick(object sender, EventArgs e)
        {
            ClientSizeAnimation(257, 42);
        }
    }
}
