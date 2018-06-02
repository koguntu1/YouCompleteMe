using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouCompleteMe.DAL
{
    public static class DBConnection
    {
        //This method returns the SQL connection for the database
        public static SqlConnection GetConnection()
        {

            string connectionString =
            "Data Source=den1.mssql1.gear.host;Initial Catalog=PROJECT6920;" +
            "User Id=project6920;Password=Mt2K?g9dtCo?";
            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}
