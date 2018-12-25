using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunEkrani
{
    class Urunler
    {
        static string constr = "Data Source=.;Initial Catalog=test;Integrated Security=True";

        SqlConnection sqlcon;
        SqlCommand command;
        private bool _hata;

        public bool Hata
        {
            get { return _hata; }
            set { _hata = value; }
        }
        private string  _hataMesaji;

        public string  HataMesaji
        {
            get { return _hataMesaji; }
            set { _hataMesaji = value; }
        }


        private String _UrunAdi;
        public String UrunAdi
        {
            get { return _UrunAdi; }
            set { _UrunAdi = value; }
        }

        private string  _barkod;
        public string  Barkod
        {
            get { return _barkod; }
            set { _barkod = value; }
        }

        private int _miktar;
        public int Miktar
        {
            get { return _miktar; }
            set {
                    if (value <= 0)
                    {
                        _hata = true;
                        _hataMesaji = "Urun Miktari 0'dan buyuk olmali ";
                        return;
                    }

                        _miktar = value;
                    }
        }

        private int _birim;
        public int Birim
        {
            get { return _birim; }
            set { _birim = value; }
        }

        private DateTime _rafOmru;
        public DateTime RafOmru
        {
            get { return _rafOmru; }
            set { _rafOmru = value; }
        }

        private string _mesei;
        public string Mensei
        {
            get { return _mesei; }
            set { _mesei = value; }
        }


        public Urunler()
        {
            UrunAdi = "";
            Barkod = "";
            Miktar = 1;
            Birim = 1;
            RafOmru = DateTime.Now.AddMonths(12);
            Mensei = "";
        }
        public int Ekle()
        {
            int sonuc = 0;
            try
            {

            
                    sqlcon = new SqlConnection(constr);

                    command = new SqlCommand();
                    command.Connection = sqlcon;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UrunEkle";
                    command.Parameters.AddWithValue("@urunAdi", UrunAdi);
                    command.Parameters.AddWithValue("@barkod", Barkod);
                    command.Parameters.AddWithValue("@miktar", Miktar);
                    command.Parameters.AddWithValue("@birim", Birim);
                    command.Parameters.AddWithValue("@rafOmru", RafOmru);
                    command.Parameters.AddWithValue("@mensei", Mensei);

                    sqlcon.Open();
                    sonuc = command.ExecuteNonQuery();
                    sqlcon.Close();

            }
            catch (Exception ex)
            {
                Hata = true;
                HataMesaji = ex.Message;
               
            }
            return sonuc;
        }
    }
}
