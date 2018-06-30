using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouCompleteMe.DAL
{
    class TimerDAL
    {
        public static Models.Task checkForTask(int taskID)
        {
            Models.Task task = new Models.Task();
            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement = "SELECT * FROM activities WHERE taskID = @taskID";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

            selectCommand.Parameters.AddWithValue("@taskID", taskID);

            SqlDataReader reader = null;
            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    task.taskID = Convert.ToInt32(reader["taskID"]);
                }
                else
                {
                    task = null;
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
            return task;
        }

        public static int updateTaskAlreadyInActivities(int taskID, int timerSecs)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string updateStatement = "UPDATE activities set " +
                                     "seconds = seconds + @seconds " +
                                     "WHERE taskID = @taskID";
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@seconds", timerSecs);
            updateCommand.Parameters.AddWithValue("@taskID", taskID);

            SqlDataReader reader = null;
            try
            {
                connection.Open();
                return updateCommand.ExecuteNonQuery();
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
        }

        public static int AddActivity(int taskID, int timerSecs)
        {
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            string insertStatement =
                "INSERT activities " +
                  "(taskID, seconds) " +
                "VALUES (@taskID, @seconds)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@taskID", taskID);
            insertCommand.Parameters.AddWithValue("@seconds", timerSecs);

            try
            {

                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT IDENT_CURRENT('tasks') FROM tasks";
                SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
                int activityID = Convert.ToInt32(selectCommand.ExecuteScalar());

                return activityID;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
