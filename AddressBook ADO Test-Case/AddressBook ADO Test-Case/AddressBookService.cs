using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_ADO_Test_Case
{
    public class AddressBookService
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Address_Book_SystemService_Database;";

        public string TestAddAddressBookInDB(AddressBook address)
        {
            SqlConnection sQLConnection = new SqlConnection(connectionString);
            try
            {
                using (sQLConnection)
                {
                    sQLConnection.Open();
                    SqlCommand command = new SqlCommand("SPAddAddressBook", sQLConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", address.FirstName);
                    command.Parameters.AddWithValue("@LastName", address.LastName);
                    command.Parameters.AddWithValue("@Address", address.Address);
                    command.Parameters.AddWithValue("@City", address.City);
                    command.Parameters.AddWithValue("@State", address.State);
                    command.Parameters.AddWithValue("@Zip", address.Zip);
                    command.Parameters.AddWithValue("@MobNo", address.MobNo);
                    command.Parameters.AddWithValue("@Email", address.Email);
                    command.Parameters.AddWithValue("@Type", address.Type);
                    command.Parameters.AddWithValue("@AddressBookName", address.AddressBookName);
                    int result = command.ExecuteNonQuery();
                    sQLConnection.Close();
                    if (result >=1)
                    {
                        Console.WriteLine("Address Book Added Succesfully");
                        return "Saved";
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                        return "NOTSAVED";
                    }
                }
            }
            catch (Exception ex)
            {
                //Handle Exception Here
                System.Console.WriteLine(ex.Message);
               
            }
            return null;
        }
        public string RetrieveEntriesFromAddressBookDB()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                List<AddressBook> addressBooks = new List<AddressBook>();
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("SPRetrieveAllDetails", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            AddressBook addressBook = new AddressBook();
                            addressBook.FirstName = dr.GetString(0);
                            addressBook.LastName = dr.GetString(1);
                            addressBook.Address = dr.GetString(2);
                            addressBook.City = dr.GetString(3);
                            addressBook.State = dr.GetString(4);
                            addressBook.Zip = dr.GetInt32(5);
                            addressBook.MobNo = dr.GetInt32(6);
                            addressBook.Email = dr.GetString(7);
                            addressBook.Type = dr.GetString(8);
                            addressBook.AddressBookName = dr.GetString(9);
                            Console.WriteLine("FirstName" + addressBook.FirstName);
                            Console.WriteLine("LastName" + addressBook.LastName);
                            Console.WriteLine("Address" + addressBook.Address);
                            Console.WriteLine("City" + addressBook.City);
                            Console.WriteLine("State" + addressBook.State);
                            Console.WriteLine("Zip" + addressBook.Zip);
                            Console.WriteLine("MobNo" + addressBook.MobNo);
                            Console.WriteLine("Email" + addressBook.Email);
                            Console.WriteLine("Type" + addressBook.Type);
                            Console.WriteLine("AddressBookName" + addressBook.AddressBookName);
                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                        }

                    }
                    else
                    {
                        Console.WriteLine("No Database Found");

                    }
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public string UpdateDataInDB(AddressBook address)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPUpdateDataInDB", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", address.FirstName);
                    command.Parameters.AddWithValue("@Address", address.Address);
                    command.Parameters.AddWithValue("@MobNo", address.MobNo);
                    int result = command.ExecuteNonQuery();
                    sqlconnection.Close();
                    if (result >= 1)
                    {

                        Console.WriteLine("AddressBook Data Updated Successfully");
                        return "Updated Succesfully";
                    }
                    else
                        Console.WriteLine("No DataBase found");
                    return "Not-Updated Succesfully";
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public void DeleteDataFromDatabase(string name)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPDeleteDataFromDB", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", name);

                    int result = command.ExecuteNonQuery();
                    sqlconnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("AddressBook Deleted Successfully");
                    }
                    else
                        Console.WriteLine("No DataBase found");
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }

        }
        public static void Main(string[]args)
        {

        }

    }
}

