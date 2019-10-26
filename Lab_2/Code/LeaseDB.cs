using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab_2.Code
{
    [DataObject(true)]
    public static class LeaseDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]

        public static List<Lease> GetLeases()
        {
            List<Lease> leases = new List<Lease>();  //empty list
            Lease ls; //just for reading      variables expressed before the commands!
            //create the connection
            SqlConnection connection = MarinaDB.GetConnection();

            //create the command  for SELECT query to get the states
            string query = "SELECT ID, SlipID, CustomerID " +
                           "FROM Lease " +
                           "ORDER by ID";

            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                //open the connection
                connection.Open();
                //run the command
                SqlDataReader reader = cmd.ExecuteReader(); //built-in

                //each state data returned, make state object and add to the list
                while (reader.Read()) //while there still is data to read
                {
                    ls = new Lease();
                    ls.ID = (int)reader["ID"];  //[]  indexer from chapter 13
                    ls.SlipID = (int)reader["ID"];
                    ls.CustomerID = (int)reader["ID"];
                    leases.Add(ls);
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
            return leases;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Lease> GetCustomerLeases()  
        {
            List<Lease> leases = new List<Lease>();  //empty list
            Lease ls; //just for reading      variables expressed before the commands!

            // Dummy variable for the customer ID - We need to use Session["ID"] - Not working so far.
            
            int custID = (int)HttpContext.Current.Session["ID"];


            //create the connection
            SqlConnection connection = MarinaDB.GetConnection();


            //create the command  for SELECT query to get the states
            string query = "SELECT ID, SlipID, CustomerID " +
                           "FROM Lease " +
                           "WHERE CustomerID = " + custID +
                           " ORDER by ID";

            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                //open the connection
                connection.Open();
                //run the command
                SqlDataReader reader = cmd.ExecuteReader(); //built-in

                //each state data returned, make state object and add to the list
                while (reader.Read()) //while there still is data to read
                {
                    ls = new Lease();
                    ls.ID = (int)reader["ID"];  //[]  indexer from chapter 13
                    ls.SlipID = (int)reader["SlipID"];
                    ls.CustomerID = (int)reader["CustomerID"];
                    leases.Add(ls);
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
            return leases;
        }
        public static bool AddLease(int slipID)  // changed Customer names in brackets
        {
            bool success = false; // did not update

            int custID = (int)HttpContext.Current.Session["ID"];

            //int custID = 1;

            // connection
            SqlConnection connection = MarinaDB.GetConnection();
            // update command
            string insertStatement =
                "INSERT INTO Lease(SlipID, CustomerID) " +
                "VALUES(@SlipID, @CustomerID)";

            SqlCommand cmd = new SqlCommand(insertStatement, connection);
            cmd.Parameters.AddWithValue("@SlipID", slipID);
            cmd.Parameters.AddWithValue("@CustomerID", custID);

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