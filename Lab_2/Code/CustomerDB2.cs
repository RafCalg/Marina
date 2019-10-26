using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab_2.Code
{
    [DataObject(true)]
    public static class CustomerDB2
    {
        [DataObjectMethod(DataObjectMethodType.Select)]

        public static List<Customer> GetCustomer()
        {
            List<Customer> customers = new List<Customer>();  //empty list
            Customer cstmr; //just for reading      variables expressed before the commands!
            //create the connection
            SqlConnection connection = MarinaDB.GetConnection();

            //create the command  for SELECT query to get the states
            string query = "SELECT CustomerID, FirstName, LastName, Phone, City " +
                          "FROM Customers " +
                          "ORDER by LastName";

            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                //open the connection
                connection.Open();
                //run the command
                SqlDataReader reader = cmd.ExecuteReader(); //built-in

                //each state data returned, make state object and add to the list
                while (reader.Read()) // while there are customers 
                {
                    cstmr = new Customer();
                    cstmr.ID = (int)reader["CustomerID"];
                    cstmr.FirstName = reader["FirstName"].ToString();
                    cstmr.LastName = reader["LastName"].ToString();
                    cstmr.Phone = reader["Phone"].ToString();
                    cstmr.City = reader["City"].ToString();
                    customers.Add(cstmr);
                }
                reader.Close();

            }
            catch (Exception ex)  //error   
            {
                throw ex;
            }
            finally  //executes always
            {
                connection.Close();
            }

            //return the list of states
            return customers;
        }
    }
}