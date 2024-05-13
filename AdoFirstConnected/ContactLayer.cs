
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdoFirstConnected
{
    internal class ContactLayer
    {
        private string _connectionstring;
        public ContactLayer()
        {
            _connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBook;Integrated Security=True;";
        }

        public void Insert(Contact c)
        {
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into Contact (firstName, lastName, address, city, state, zip, phone, email, bookName) values (@firstName, @lastName, @address, @city, @state, @zip, @phone, @email, @bookName)", con);
                    
                    cmd.Parameters.AddWithValue("@firstName", c.firstName);
                    cmd.Parameters.AddWithValue("@lastName", c.lastName);
                    cmd.Parameters.AddWithValue("@address", c.address);
                    cmd.Parameters.AddWithValue("@city", c.city);
                    cmd.Parameters.AddWithValue("@state", c.state);
                    cmd.Parameters.AddWithValue("@zip", c.zip);
                    cmd.Parameters.AddWithValue("@phone", c.phone);
                    cmd.Parameters.AddWithValue("@email", c.email);
                    cmd.Parameters.AddWithValue("@bookName", c.bookName);

                    con.Open();
                    int rowsaffected = cmd.ExecuteNonQuery();

                    Console.WriteLine("Rows Affected= " + rowsaffected);
                }
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void DisplayAll()
        {
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select firstName, lastName, address, city, state, zip, phone, email, bookName from Contact;", con);

                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Console.WriteLine("Name: " + sdr[0].ToString() + " " + sdr[1].ToString() + ", Phone: " + sdr["phone"].ToString() + ", Email: " + sdr["email"].ToString());
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void DisplayByName(string name)
        {
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select firstName, lastName, address, city, state, zip, phone, email, bookName from Contact where firstName=@name", con);
                    cmd.Parameters.AddWithValue("@name", name);

                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Console.WriteLine("Name: " + sdr[0].ToString() + " " + sdr[1].ToString() + ", Phone: " + sdr["phone"].ToString() + ", Email: " + sdr["email"].ToString());
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
