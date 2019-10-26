using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab_2.Code
{
    [DataObject(true)]
    public static class DockDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]

        public static List<Dock> GetDocks()
        {
            List<Dock> docks = new List<Dock>();  //empty list
            Dock d; //just for reading      variables expressed before the commands!
            //create the connection
            SqlConnection connection = MarinaDB.GetConnection();

            //create the command  for SELECT query to get the states
            string query = "SELECT ID, Name, WaterService, ElectricalService " +
                           "FROM Dock " +
                           "ORDER by Name";

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
                    d = new Dock();
                    d.ID = (int)reader["ID"];  //[]  indexer from chapter 13
                    d.Name = reader["Name"].ToString();
                    d.WaterService = reader["WaterService"].ToString();
                    d.ElectricalService = reader["ElectricalService"].ToString();
                    docks.Add(d);
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
            return docks;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Dock> GetSelectedDocks(int ID)
        {
            List<Dock> docks = new List<Dock>();  //empty list
            Dock d; //just for reading      variables expressed before the commands!
            //create the connection
            SqlConnection connection = MarinaDB.GetConnection();

            //create the command  for SELECT query to get the states
            string query = "SELECT ID, Name, WaterService, ElectricalService " +
                           "FROM Dock " +
                           "WHERE ID = @ID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", ID);
            try
            {
                //open the connection
                connection.Open();
                //run the command
                SqlDataReader reader = cmd.ExecuteReader(); //built-in

                //each state data returned, make state object and add to the list
                while (reader.Read()) //while there still is data to read
                {
                    d = new Dock();
                    d.ID = (int)reader["ID"];  //[]  indexer from chapter 13
                    d.Name = reader["Name"].ToString();
                    d.WaterService = reader["WaterService"].ToString();
                    d.ElectricalService = reader["ElectricalService"].ToString();
                    docks.Add(d);
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
            return docks;
        }
    }
}