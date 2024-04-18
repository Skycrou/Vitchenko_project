using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WEB_LAP
{
    public class Database
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-DIO3QU7\SQLEXPRESS; Initial Catalog=VitchenkoAA; Integrated Security=true");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();

                int g;
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();

            }
        }
        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}