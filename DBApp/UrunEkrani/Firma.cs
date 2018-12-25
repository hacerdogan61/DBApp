using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
namespace UrunEkrani
{
    class Firma
    {
        SqlConnection con;
        SqlCommand cmd;
        
        private bool _hatavar;

        public bool HataVar
        {
            get { return _hatavar; }
            set { _hatavar = value; }
        }

        private string _hataMesaji;

        public string HataMesaji
        {
            get { return _hataMesaji; }
            set { _hataMesaji = value; }
        }


        private string _unvan;

        public string Unvan
        {
            get { return  _unvan; }
            set { _unvan = value; }
        }

        private int _firmaTipi;

        public int FirmaTipi
        {
            get { return _firmaTipi; }
            set { _firmaTipi = value; }
        }


        private string  _adres1;

        public string  Adres1
        {
            get { return _adres1; }
            set { _adres1 = value; }
        }

        private string _adres2;

        public string Adres2
        {
            get { return _adres2; }
            set { _adres2 = value; }
        }

        private string  _vergiDairesi;

        public string  VergiDairesi
        {
            get { return _vergiDairesi; }
            set { _vergiDairesi = value; }
        }

        private string _vergiNo;

        public string VergiNo
        {
            get { return _vergiNo; }
            set { _vergiNo = value; }
        }
        public Firma()
        {
            Unvan = "Belirsiz";
            FirmaTipi = 0;
            Adres1 = "";
            Adres2 = "";
            VergiDairesi = "Yok";
            VergiNo = "";
        }

        public int Ekle()
        {
            int sonuc = 0;
            try
            {


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["testDB"].ConnectionString);
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText="FirmaEkleErcan";
            cmd.Parameters.AddWithValue("@Unvan", Unvan);
            cmd.Parameters.AddWithValue("@firmaTipi", FirmaTipi);
            cmd.Parameters.AddWithValue("@adres1", Adres1);
            cmd.Parameters.AddWithValue("@adres2", Adres2);
            cmd.Parameters.AddWithValue("@Vergidairesi", VergiDairesi);
            cmd.Parameters.AddWithValue("@VergiNo", VergiNo);

            con.Open();
            sonuc = cmd.ExecuteNonQuery();
           
            }
            catch (Exception ex)
            {
                HataVar = true;
                HataMesaji = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return sonuc;
        }
        public List<Firma> FirmalariVer()
        {
            List<Firma> f = new List<Firma>();

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["testDb"].ConnectionString);

            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " Select * from Firma ";
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Firma firma = new Firma();
                firma.Unvan = rdr["Unvan"].ToString();
                firma.Adres1 = rdr["adres1"].ToString();
                firma.Adres2 = rdr["adres2"].ToString();
                firma.FirmaTipi = Int32.Parse(rdr["firmatipi"].ToString());
                firma.VergiDairesi = rdr["vergiDairesi"].ToString();
                firma.VergiNo = rdr["vergiNo"].ToString();

                f.Add(firma);
            }



            con.Close();
            return f;
        }
    }
}
