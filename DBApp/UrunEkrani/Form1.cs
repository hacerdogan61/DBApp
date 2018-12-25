using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace UrunEkrani
{
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Urunler u = new Urunler();
            u.UrunAdi = txtUrunAdi.Text;
            u.Barkod = txtBarkod.Text;
            u.Miktar = Int32.Parse(txtMiktar.Text);
            u.Birim = 1;
            u.RafOmru = DateTime.Now.AddMonths(12);
            u.Mensei = txtMensei.Text;

            u.Ekle();
            if (u.Hata == true)
                MessageBox.Show("Alinan Hata :" + u.HataMesaji);
            else
                MessageBox.Show("Kayit Eklenmiştir");

        }
    }
}
