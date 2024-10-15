using Domen.Entiteti;
using Domen.Util;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {
        public FrmServer()
        {
            InitializeComponent();
            button1.Enabled = true;
            button2.Enabled = false;
            textBox1.Text = ConfigurationManager.AppSettings["MaxUsers"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var serverUspesnoPokrenut = ServerNit.Instance.Start();
            button1.Enabled = !serverUspesnoPokrenut;
            button2.Enabled = serverUspesnoPokrenut;
            MessageBox.Show(serverUspesnoPokrenut
                ? "Server je uspesno pokrenut"
                : "Doslo je do greske prilikom pokretanja servera");

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var serverUspesnoZaustavljen = ServerNit.Instance.Stop();
            button1.Enabled = serverUspesnoZaustavljen;
            button2.Enabled = !serverUspesnoZaustavljen;
            MessageBox.Show(serverUspesnoZaustavljen
                ? "Server je uspesno zaustavljen"
                : "Doslo je do greske prilikom zaustavljanja servera");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                return;
            }

            if (int.TryParse(textBox1.Text, out var maxUsers))
            {
                ConfigurationManager.AppSettings["UserId"] = maxUsers.ToString();
            }

        }
    }
}
