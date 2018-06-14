using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouCompleteMe.Models;

namespace YouCompleteMe.DAL
{
    class TasksDAL
    {
        // Only update the task to the currentDate if it is not complete
        public static int updateIncompleteTasksToCurrentDate()
        {
            SqlConnection connection = DBConnection.GetConnection();
            string updateStatement =
                "UPDATE tasks set " +
                "currentDate = GETDATE() " +
                "WHERE completed = 0";
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);

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

        // Get all tasks for the current user associated with the selected date
        public static List<TaskModel> getCurrentUsersTasks(User currentUser, string date)
        {
            List<TaskModel> tasks = new List<TaskModel>();

            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement =
                "SELECT * FROM tasks " +
                "WHERE " +
                "task_owner = @user and " +
                "cast(currentDate as date) = @date " +
                "order by deadline, task_priority";

            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@user", currentUser.userID);
            selectCommand.Parameters.AddWithValue("@date", date);

            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    TaskModel task = new TaskModel();
                    task.task_owner = Convert.ToInt32(reader["task_owner"]);
                    task.taskID = Convert.ToInt32(reader["taskID"]);
                    task.taskType = Convert.ToInt32(reader["taskType"]);
                    task.task_priority = Convert.ToInt32(reader["task_priority"]);
                    task.completed = Convert.ToInt32(reader["completed"]);
                    task.title = reader["title"].ToString();
                    task.createdDate = (DateTime)reader["createdDate"];
                    task.currentDate = (DateTime)reader["currentDate"];
                    task.deadline = (DateTime)reader["deadline"];

                    tasks.Add(task);
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

            return tasks;
        }
        // Get the current completed status
        public static int checkCompleteStatus(int taskID)
        {
            int completed;
            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement = "select completed " +
                                     "FROM tasks " +
                                     "where taskID = @taskID";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@taskID", taskID);
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                completed = Convert.ToInt16(selectCommand.ExecuteScalar());

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

            return completed;
        }
        // Update a task to complete status
        public static int updateTaskCompleted(int taskID)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string updateStatement = "UPDATE tasks " +
                                     "set completed = 1 " +
                                     "WHERE taskID = @taskID";
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@taskID", taskID);

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
        public static int updateTaskIncomplete(int taskID)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string updateStatement = "UPDATE tasks " +
                                     "set completed = 0, " +
                                     "currentDate = GETDATE() " +
                                     "WHERE taskID = @taskID";
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@taskID", taskID);

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
