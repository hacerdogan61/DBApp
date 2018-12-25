using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data;
namespace DBApp
{
    class Program
    {
       static string constr = "Data Source=.;Initial Catalog=test;Integrated Security=True";
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            Console.WriteLine($"Connection State {con.State}");
            con.Close();
            Console.WriteLine($"Connection State {con.State}");
            Console.ReadLine();

            

        }
    }
}
