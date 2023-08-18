using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign6
{
    internal class Program
    {
        private static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;
        static string conStr = "server=DESKTOP-KQQHHP5\\SQLEXPRESS; database=ProductInventoryDb; trusted_connection=true;";
        static void Main(string[] args)
        {
            try
            {
                con = new SqlConnection(conStr);
                cmd = new SqlCommand("select * from Products", con);
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("ProductId: " + reader["ProductId"]);
                    Console.WriteLine("ProductName: " + reader["ProductName"]);
                    Console.WriteLine("Price: " + reader["Price"]);
                    Console.WriteLine("Quantity: " + reader["Quantity"]);
                    Console.WriteLine("MfDate: " + reader["MfDate"]);
                    Console.WriteLine("ExpDate: " + reader["ExpDate"]);
                    Console.WriteLine("_______________________________________________________________");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!! " + ex.Message);
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }
    }
}
