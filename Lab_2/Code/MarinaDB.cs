using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab_2.Code
{
    public class MarinaDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=Marina;Integrated Security=True";
            return new SqlConnection(connectionString);
        }
    }
}