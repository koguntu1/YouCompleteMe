using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouCompleteMe.Models;

namespace YouCompleteMe.DAL
{
    public static class UserDAL
    {
        //Creates a new user in the database
        public static void createUser(string username, string fName, string lName, string email, string phone, string password, string hint)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string insertStatement =
                "INSERT users " +
                "(username, fName, lName, email, phone, enc_password, hint) " +
                "VALUES " +
                "(@username, @fName, @lName, @email, @phone, @password, @hint)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@username", username);
            insertCommand.Parameters.AddWithValue("@fName", fName);
            insertCommand.Parameters.AddWithValue("@lName", lName);
            insertCommand.Parameters.AddWithValue("@email", email);
            insertCommand.Parameters.AddWithValue("@phone", phone);
            insertCommand.Parameters.AddWithValue("@password", password);
            insertCommand.Parameters.AddWithValue("@hint", hint);

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

        //Returns a list of all users from the database
        public static List<User> getUsers()
        {
            List<User> users = new List<User>();
            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement = "SELECT * " +
                "FROM users ";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();

                    user.userName = reader["username"].ToString();
                    user.email = reader["email"].ToString();

                    users.Add(user);
                }
                reader.Close();
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
                if (reader != null)
                    reader.Close();
            }
            return users;
        }

        //Returns specified user based on username and password
        public static User getAUser(string username, string password)
        {
            User user = new User();
            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement = "SELECT * " +
                "FROM users " +
                 "WHERE username = @username AND enc_password = @password"; ;
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

            selectCommand.Parameters.AddWithValue("@username", username);
            selectCommand.Parameters.AddWithValue("@password", password);
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();
                if (reader.Read())
                {
                    user.userID = Convert.ToInt32(reader["userID"]);
                    user.fName = reader["fName"].ToString();
                    user.lName = reader["lName"].ToString();
                    user.email = reader["email"].ToString();
                    user.phone = reader["phone"].ToString();
                    user.userName = reader["userName"].ToString();
                    user.password = reader["enc_password"].ToString();
                    user.hint = reader["hint"].ToString();
                }
                else
                {
                    user = null;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                if (reader != null)
                    reader.Close();
            }
            return user;
        }

        //Returns the password for the passed user
        public static String getPassword(string username)
        {
            string password = "";
            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement = "SELECT enc_password " +
                "FROM users " +
                "WHERE username = @Username";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@Username", username);

            SqlDataReader reader = null;
            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow);

                while (reader.Read())
                {
                    password = reader["enc_password"].ToString();
                }
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
                if (reader != null)
                    reader.Close();
            }
            return password;
        }

        //Returns specified user based on username and password
        public static User verifyAUser(string username, string hint)
        {
            User user = new User();
            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement = "SELECT * " +
                "FROM users " +
                 "WHERE username = @username AND hint = @hint"; ;
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

            selectCommand.Parameters.AddWithValue("@username", username);
            selectCommand.Parameters.AddWithValue("@hint", hint);
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();
                if (reader.Read())
                {
                    user.userID = Convert.ToInt32(reader["userID"]);
                    user.fName = reader["fName"].ToString();
                    user.lName = reader["lName"].ToString();
                    user.email = reader["email"].ToString();
                    user.phone = reader["phone"].ToString();
                    user.userName = reader["userName"].ToString();
                }
                else
                {
                    user = null;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                if (reader != null)
                    reader.Close();
            }
            return user;
        }

        //Updates the password for the passed user to the passed password
        public static void updatePassword(string username, string password)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string updateStatement = "UPDATE users " +
                "SET enc_password = @Password " +
                "WHERE username = @Username";
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@Username", username);
            updateCommand.Parameters.AddWithValue("@Password", password);
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                updateCommand.ExecuteNonQuery();
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
                if (reader != null)
                    reader.Close();
            }
        }

        //Updates the password for the passed user to the passed password
        public static void updateUser(string fName, string lName, string email, string phone, string hint, int id)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string updateStatement = "UPDATE users " +
                "SET fName = @fName, " +
                "lName = @lName, " +
                "email = @email, " +
                "phone = @phone, " +
                "hint = @hint " +
                "WHERE userID = @id";
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@fName", fName);
            updateCommand.Parameters.AddWithValue("@lName", lName);
            updateCommand.Parameters.AddWithValue("@email", email);
            updateCommand.Parameters.AddWithValue("@phone", phone);
            updateCommand.Parameters.AddWithValue("@hint", hint);
            updateCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                updateCommand.ExecuteNonQuery();
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
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
