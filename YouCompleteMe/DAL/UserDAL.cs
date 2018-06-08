using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouCompleteMe.DAL
{
    public static class UserDAL
    {
        public static void createUser(string username, string fName, string lName, string email, string phone, string password)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string insertStatement =
                "INSERT users " +
                "(username, fName, lName, email, phone, enc_password) " +
                "VALUES " +
                "(@username, @fName, @lName, @email, @phone, @password)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@username", username);
            insertCommand.Parameters.AddWithValue("@fName", fName);
            insertCommand.Parameters.AddWithValue("@lName", lName);
            insertCommand.Parameters.AddWithValue("@email", email);
            insertCommand.Parameters.AddWithValue("@phone", phone);
            insertCommand.Parameters.AddWithValue("@password", password);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
    }
}
