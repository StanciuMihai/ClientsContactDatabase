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
            //Create a default return type and set its value to false
            bool isSuccess = false;

            //Step 1 connect database
            SQLiteConnection conn = new SQLiteConnection(myconnstrng);
            try
            {
                //Step 2 create sql query to insert data
                string sql = "Insert INTO tbl_contact (FirstName, LastName, ContactNo, Address, Gender) VALUES(@FirstName, @LastName, @ContactNo, @Address, @Gender)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                //Create parameters to add data
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.@Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if(rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        //Update data in database
        public bool Update(contactClass c)
        {
            //Create a default return type and set its value to false
            bool isSuccess = false;

            //Step 1 connect database
            SQLiteConnection conn = new SQLiteConnection(myconnstrng);
            try
            {
                //Step 2 create sql query to update data
                string sql = "UPDATE tbl_contact SET FirstName=@FirstName, LastName=@LastName, ContactNo=@ContactNo, Address=@Address, Gender=@Gender WHERE ContactID=@ContactID";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                //Create parameters to add data
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.@Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        //Delete data from database
        public bool Delete(contactClass c)
        {
            //Create a default return type and set its value to false
            bool isSuccess = false;

            //Step 1 connect database
            SQLiteConnection conn = new SQLiteConnection(myconnstrng);
            try
            {
                //Step 2 create sql query to update data
                string sql = "DELETE FROM tbl_contact WHERE ContactID=@ContactID";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                //Create parameters to add data
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);
                

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

    }
}
