using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class MarinaDB
    {
        public static SqlConnection GetConnection()  //method which needs a call and return   this will be called in the StateDB (when connection needs to be made)
        {
            string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=Marina;Integrated Security=True";  //@ allows you to put the entire path 
            //regardless of special characters
            return new SqlConnection(connectionString);
        }
    }
}
