using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouCompleteMe.Models;

namespace YouCompleteMe.DAL
{
    class SubtaskDAL
    {
        public static List<Subtask> getSubtasksForTask(User currentUser, int taskID)
        {
            List<Subtask> subtasks = new List<Subtask>();

            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement =
                "SELECT * FROM subtask " +
                "WHERE " +
                "taskID = @task " +
                "order by st_Deadline, st_Priority";

            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@user", currentUser.userID);
            selectCommand.Parameters.AddWithValue("@task", taskID);

            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Subtask subtask = new Subtask();
                    subtask.taskID = Convert.ToInt32(reader["taskID"]);
                    subtask.subtaskID = Convert.ToInt32(reader["subtaskID"]);
                    subtask.st_Description =reader["st_Description"].ToString();
                    //task.completed = Convert.ToInt32(reader["completed"]);
                    subtask.st_CreatedDate = (DateTime)reader["st_CreatedDate"];
                    if (reader["st_CompleteDate"] != DBNull.Value)
                        subtask.st_CompleteDate = (DateTime)reader["st_CompleteDate"];
                    else
                        subtask.st_CompleteDate = DateTime.MaxValue;
                    if (reader["st_Deadline"] != DBNull.Value)
                        subtask.st_Deadline = (DateTime)reader["st_Deadline"];
                    else
                        subtask.st_Deadline = DateTime.MaxValue;
                    subtask.st_Priority = Convert.ToInt32(reader["st_Priority"]);

                    subtasks.Add(subtask);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return subtasks;
        }

        // Update a subtask to complete status
        public static int updateSubtaskCompleted(int subtaskID)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string updateStatement = "UPDATE subtask " +
                                     "set st_CompleteDate = getDate() " +
                                     "WHERE subtaskID = @subtaskID";
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@subtaskID", subtaskID);

            SqlDataReader reader = null;
            try
            {
                connection.Open();

                // Returns the number of rows affected by this update
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
        public static int updateSubtaskIncomplete(int subtaskID)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string updateStatement = "UPDATE subtask " +
                                     "set st_CompleteDate = @null " +
                                     "WHERE subtaskID = @subtaskID";
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@subtaskID", subtaskID);
            updateCommand.Parameters.AddWithValue("@null", DBNull.Value);

            SqlDataReader reader = null;
            try
            {
                connection.Open();

                // Returns the number of rows affected by this update
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
    }
}
