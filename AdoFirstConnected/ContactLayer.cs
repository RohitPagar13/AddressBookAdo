
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

                    Console.WriteLine("Added to the Address Book \nRows Affected= " + rowsaffected);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
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
                    if (sdr.HasRows)
                    {
                        Console.WriteLine("Below are the all Contacts in the Address Book \n");
                        while (sdr.Read())
                        {
                            Console.WriteLine("Name: " + sdr[0].ToString() + " " + sdr[1].ToString() + ", Phone: " + sdr["phone"].ToString() + ", Email: " + sdr["email"].ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data exists");
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

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Console.WriteLine("Name: " + sdr[0].ToString() + " " + sdr[1].ToString() + ", Phone: " + sdr["phone"].ToString() + ", Email: " + sdr["email"].ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data exists for the name "+name);
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

        public void Delete(string name)
        {
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("delete from Contact where firstName=@name", con);
                    cmd.Parameters.AddWithValue("@name", name);

                    con.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("deleted rows: " + rowsAffected);
                    }
                    else
                    {
                        Console.WriteLine(name + " does not exists");
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

        public void Update(string fName, Contact c)
        {
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Update Contact set firstName=@firstName , lastName=@lastName, address= @address, city=@city, state=@state, zip=@zip, phone=@phone, email=@email, bookName=@bookName where firstName=@fname", con);
                    cmd.Parameters.AddWithValue("@firstName", c.firstName);
                    cmd.Parameters.AddWithValue("@lastName", c.lastName);
                    cmd.Parameters.AddWithValue("@address", c.address);
                    cmd.Parameters.AddWithValue("@city", c.city);
                    cmd.Parameters.AddWithValue("@state", c.state);
                    cmd.Parameters.AddWithValue("@zip", c.zip);
                    cmd.Parameters.AddWithValue("@phone", c.phone);
                    cmd.Parameters.AddWithValue("@email", c.email);
                    cmd.Parameters.AddWithValue("@bookName", c.bookName);

                    cmd.Parameters.AddWithValue("@fName", fName);

                    con.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Updated rows: " + rowsAffected);
                    }
                    else
                    {
                        Console.WriteLine(fName + " does not exists");
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

        public void Count()
        {
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select count(*) from Contact", con);
                    con.Open();
                    var count = cmd.ExecuteScalar();
                    Console.WriteLine("No of Contacts in the AddressBook: "+count);
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
