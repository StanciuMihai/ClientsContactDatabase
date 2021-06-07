using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsContactDatabase
{
    public class contactClass
    {
        //Get and Set properties for contacts
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        //Select data from database

        public DataTable Select()
        {
            //Step 1 Database connection
            SQLiteConnection conn = new SQLiteConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                //Step 2 Writing SQLite query
                string sql = "SELECT * FROM tbl_contact";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);   
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        //Insert data to database
        public bool Insert (contactClass c)
        {

        }
      

    }
}
