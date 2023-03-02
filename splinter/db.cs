using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace splinter
{
    class db
    {
        public static void connect()
        {
            string connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Execute SQL commands here

                connection.Close();
            }

        }
    }
}
