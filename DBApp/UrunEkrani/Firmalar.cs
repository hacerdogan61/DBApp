using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;

namespace UrunEkrani
{
    public partial class Firmalar : Form
    {
        public Firmalar()
        {
            InitializeComponent();


           Text= ConfigurationManager.AppSettings["ProgramAdi"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (!string.IsNullOrEmpty(txtFirmaAdi.Text) )
            {
                Firma f = new Firma();
                f.Unvan = txtFirmaAdi.Text.ToString();
                f.FirmaTipi = comboFirmaTip.SelectedIndex + 1;
                f.Adres1 = txtAdres1.Text;
                f.Adres2 = txtAdres2.Text;
                f.VergiDairesi = txtVergiD.Text;
                f.VergiNo = txtVergiNo.Text;
                
                if (f.Ekle() > 0)
                {
                    MessageBox.Show("KAyit Başarili Şekilde Eklenmiştir");
                }
            }
            else
            {
                MessageBox.Show("Enazindan firma adini girin");
            }
            

        }
        public void ekraniTemizle()
        {
            TextBox test = new TextBox();
            test.Multiline = true;
            groupBox1.Controls.Add(test);

            txtFirmaAdi.Text = "";
            txtAdres1.Text = "";
            txtAdres2.Text = "";
            txtVergiNo.Text = "";
            txtVergiD.Text = "";

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ekraniTemizle();
            //Firma f = new Firma();
            //List<Firma> firmalar = f.FirmalariVer();
            //dataGridView1.DataSource = firmalar;
            
        }
    }
}
