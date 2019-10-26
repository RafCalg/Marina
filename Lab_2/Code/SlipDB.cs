using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Lab_2.Code
{
    [DataObject(true)]
    public static class SlipDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]

        public static List<Slip> GetSlips()
        {
            List<Slip> slips = new List<Slip>();  //empty list
            Slip s; //just for reading      variables expressed before the commands!
            //create the connection
            SqlConnection connection = MarinaDB.GetConnection();

            //create the command  for SELECT query to get the states
            string query = "SELECT ID, Width, Length, DockID, BookingStatus " +
                           "FROM Slip " +
                           "ORDER by Id";

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
                    s = new Slip();
                    s.ID = (int)reader["ID"];  //[]  indexer from chapter 13
                    s.Width = (int)(reader["Width"]);
                    s.Length = (int)(reader["Length"]);
                    s.DockID = (int)(reader["DockID"]);
                    s.BookingStatus = (int)(reader["BookingStatus"]);
                    slips.Add(s);
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

            //return the list of slips
            return slips;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]

        public static List<Slip> GetAvailableSlipsDoNotUse()
        {
            List<Slip> slips = new List<Slip>();  //empty list
            Slip s; //just for reading      variables expressed before the commands!
                    //create the connection
            int selectedDockID;
            //We need to know which dock has been selected
            System.Web.UI.Page currentPage = HttpContext.Current.Handler as System.Web.UI.Page;

            //Find controls of the LeaseSlip.aspx here 
            DropDownList dropDown = (DropDownList)currentPage.FindControl("ddlLeaseSlipDock");

            //Sets the selectedDockID value to the index of the selected item in the dropdownlist
            selectedDockID = dropDown.SelectedIndex + 1;



            SqlConnection connection = MarinaDB.GetConnection();

            //create the command  for SELECT query to get the states
            string query = "SELECT ID, Width, Length, DockID, BookingStatus " +
                           "FROM Slip " +
                           "WHERE (BookingStatus = 0 " +
                           "AND DockID = " + selectedDockID + ") " +
                           "ORDER by Id";

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
                    s = new Slip();
                    s.ID = (int)reader["ID"];  //[]  indexer from chapter 13
                    s.Width = (int)(reader["Width"]);
                    s.Length = (int)(reader["Length"]);
                    s.DockID = (int)(reader["DockID"]);
                    s.BookingStatus = (int)(reader["BookingStatus"]);
                    slips.Add(s);
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

            //return the list of slips
            return slips;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        // retrieve customers from given state
        public static List<Slip> GetSlipsByDocks(int dockID)
        {
            List<Slip> slips = new List<Slip>(); // empty list
            Slip slip = null; // for reading

            // create connection
            SqlConnection connection = MarinaDB.GetConnection();

            // create SELECT command
            string query = "SELECT ID, Width, Length, DockID, BookingStatus " +
                           "FROM Slip " +
                           "WHERE DockID = @DockID AND BookingStatus =0";

            SqlCommand cmd = new SqlCommand(query, connection);
            // supply parameter value
            cmd.Parameters.AddWithValue("@DockID", dockID);

            // run the SELECT query

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            // add customers to the list
            while (reader.Read()) // while there are customers
            {
                slip = new Slip();
                slip.ID = (int)reader["ID"];
                slip.Width = (int)reader["Width"];
                slip.Length = (int)reader["Length"];
                slip.DockID = (int)reader["DockID"];
                slip.BookingStatus = (int)reader["BookingStatus"];
                slips.Add(slip);
            }
            reader.Close();
            return slips;
        }

        //Update Slip Table
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static Slip UpdateSlipStatus(int slipID)
        {
            Slip slip = null;

            // create connection
            SqlConnection connection = MarinaDB.GetConnection();

            // create SELECT command
            string query = "SELECT ID, Width, Length, DockID, BookingStatus " +
                           "FROM Slip " +
                           "WHERE ID = " + slipID;
            SqlCommand cmd = new SqlCommand(query, connection);
            // supply parameter value
            cmd.Parameters.AddWithValue("@CustomerID", slipID);

            // run the SELECT query
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                // build customer object to return
                if (reader.Read()) // if there is a customer with this ID
                {
                    slip = new Slip();
                    slip.ID = slipID;
                    slip.Width = (int)reader["Width"];
                    slip.Length = (int)reader["Length"];
                    slip.DockID = (int)reader["DockID"];
                    slip.BookingStatus = 1;
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

            return slip;
        }


        public static bool UpdateSlip(int slipID)  // changed Customer names in brackets
        {
            bool success = false; // did not update

            // connection
            SqlConnection connection = MarinaDB.GetConnection();
            // update command
            string updateStatement =
                "UPDATE Slip SET " +
                "BookingStatus = @BookingStatus " +
                "WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(updateStatement, connection);
            
            // change customer.Name, etc to match line 164
            // change properties for Update Method, DataObjectName, Conflict Detection to Compared All Values
            cmd.Parameters.AddWithValue("@BookingStatus", 1);
            cmd.Parameters.AddWithValue("@ID", slipID);
            
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