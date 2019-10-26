using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab_2.Code
{
    [DataObject(true)]
    public static class CustomerDB
    {
        //get customer 
        //check if login is successfull
        //return customer ID if exist, otherwise, return -1
        //[DataObjectMethod(DataObjectMethodType.Select)]
        public static int getCustomer(string userName, string password)
        {
            int id = -1; //default to negative value

            string sql = "SELECT ID " +
                "FROM Customer " + "WHERE Username = @uName AND Password = @pwd";

            SqlConnection connection = MarinaDB.GetConnection();

            SqlCommand cmd = new SqlCommand(sql, connection);


            cmd.Parameters.AddWithValue("@uName", userName);
            cmd.Parameters.AddWithValue("@pwd", password);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                // build customer object to return
                if (reader.Read()) // if there is a customer with this ID
                {
                    Customer cust = new Customer();
                    //fill data from reader
                    cust.ID = (int)reader["ID"];
                    id = cust.ID;
                    //cust.Name = reader["Name"].ToString();
                    //cust.Address = reader["Address"].ToString();
                    //cust.City = reader["City"].ToString();
                    //cust.State = reader["State"].ToString();
                    //cust.ZipCode = reader["ZipCode"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return id;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        // retrieve customer with given ID
        public static List<Customer> GetCustomersByLease(int ID) 
        {
            List<Customer> customers = new List<Customer>(); // empty list
            Customer cust = null; // for reading

            // create connection
            SqlConnection connection = MarinaDB.GetConnection();

            // create SELECT command
            string query = "SELECT CustomerID, FirstName, LastName, Phone, City " +
                           "FROM Customers " +
                           "WHERE Lease = @ID";
            SqlCommand cmd = new SqlCommand(query, connection);
            // supply parameter value
            cmd.Parameters.AddWithValue("@ID", ID);

            // run the SELECT query
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                // add customer to the list 
                while (reader.Read()) // while there are customers 
                {
                    cust = new Customer();
                    cust.ID = (int)reader["CustomerID"];
                    cust.FirstName = reader["FirstName"].ToString();
                    cust.LastName = reader["LastName"].ToString();
                    cust.Phone = reader["Phone"].ToString();
                    cust.City = reader["City"].ToString(); 
                    customers.Add(cust);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return customers;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        // insert new row to table Customers
        // return new CustomerID
        public static int AddCustomer(Customer cust)
        {
            int custID = 0;

            // create connection
            SqlConnection connection = MarinaDB.GetConnection();

            // create INSERT command
            // CustomerID is IDENTITY so no value provided
            string insertStatement =
                "INSERT INTO Customers(FirstName, LastName, Phone, City) " +
                "OUTPUT inserted.CustomerID " +
                "VALUES(@FirstName, @LastName, @Phone, @City)";
            SqlCommand cmd = new SqlCommand(insertStatement, connection);
            cmd.Parameters.AddWithValue("@FirstName", cust.FirstName);
            cmd.Parameters.AddWithValue("@LastName", cust.LastName);
            cmd.Parameters.AddWithValue("@Phone", cust.Phone);
            cmd.Parameters.AddWithValue("@City", cust.City);

            try
            {
                connection.Open();

                // execute insert command and get inserted ID
                custID = (int)cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                // retrieve generate customer ID to return
                //string selectStatement =
                //    "SELECT IDENT_CURRENT('Customers')";
                //SqlCommand selectCmd = new SqlCommand(selectStatement, connection);
                //custID = Convert.ToInt32(selectCmd.ExecuteScalar()); // returns single value
                //         // (int) does not work in this case
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return custID;
        }

        // delete customer
        // return indiucator of success
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static bool DeleteCustomer(Customer cust)
        {
            bool success = false;

            // create connection
            SqlConnection connection = MarinaDB.GetConnection();

            // create DELETE command
            string deleteStatement =
                "DELETE FROM Customers " +
                "WHERE CustomerID = @CustomerID " + // needed for identification
                "AND FirstName = @FirstName " + // the rest - for optimistic concurrency
                "AND LastName = @LastName " +
                "AND Phone = @Phone " +
                "AND City = @City ";
            SqlCommand cmd = new SqlCommand(deleteStatement, connection);
            cmd.Parameters.AddWithValue("@CustomerID", cust.ID);
            cmd.Parameters.AddWithValue("@FirstName", cust.FirstName);
            cmd.Parameters.AddWithValue("@LastName", cust.LastName);
            cmd.Parameters.AddWithValue("@Phone", cust.Phone);
            cmd.Parameters.AddWithValue("@City", cust.City);

            try
            {
                connection.Open();

                // execute the command
                int count = cmd.ExecuteNonQuery();
                // check if successful
                if (count > 0)
                    success = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return success;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        // update customer
        // retirn indicator of success
        public static bool UpdateCustomer(Customer old_Customer, Customer customer)  // changed Customer names in brackets
        {
            bool success = false; // did not update

            // connection
            SqlConnection connection = MarinaDB.GetConnection();
            // update command
            string updateStatement =
                "UPDATE Customers SET " +
                "FirstName = @NewFirstName, " +
                "LastName = @NewLastName, " +
                "Phone= @NewPhone, " +
                "City = @NewCity, " +
                "WHERE CustomerID = @OldCustomerID " + // identifies ccustomer
                "AND FirstName = @OldFirstName " + // remaining - for otimistic concurrency
                "AND LastName = @OldLastName " +
                "AND Phone = @OldPhone " +
                "AND City = @OldCity ";
            SqlCommand cmd = new SqlCommand(updateStatement, connection);
            // change customer.Name, etc to match line 164
            // change properties for Update Method, DataObjectName, Conflict Detection to Compared All Values
            cmd.Parameters.AddWithValue("@NewFirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@NewLastName", customer.LastName);
            cmd.Parameters.AddWithValue("@NewPhone", customer.Phone);
            cmd.Parameters.AddWithValue("@NewCity", customer.City);
            cmd.Parameters.AddWithValue("@OldCustomerID", old_Customer.ID);
            cmd.Parameters.AddWithValue("@OldFirstName", old_Customer.FirstName);
            cmd.Parameters.AddWithValue("@OldLastName", customer.LastName);
            cmd.Parameters.AddWithValue("@OldPhone", old_Customer.Phone);
            cmd.Parameters.AddWithValue("@OldCity", old_Customer.City);

            try
            {
                connection.Open();
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    success = true; // updated
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return success;
        }
    }
}