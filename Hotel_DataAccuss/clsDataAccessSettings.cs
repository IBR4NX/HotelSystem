using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_DataAccuss
{
    public class clsDataAccessSettings
    {
        public static string ConnectionString = "Server=.;Database=Hotel;Integrated Security=true;";
        public static SqlConnection Connection = new SqlConnection(ConnectionString);

        public static SqlConnection GetConnect()
        {
            if(Connection == null)
            {
                Connection = new SqlConnection(ConnectionString);
            }

            if (Connection.State==ConnectionState.Open)
            {
                return Connection;
            }
            else
            {
                try
                {
                    Connection.Open();
                    return Connection;
                }
                catch (SqlException e)
                {
                    throw new Exception(e.Message);
                }

            }
        }

    }
}
