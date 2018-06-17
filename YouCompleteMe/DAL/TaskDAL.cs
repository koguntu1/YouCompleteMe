using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouCompleteMe.Models;

namespace YouCompleteMe.DAL
{
    class TaskDAL
    {
        /*
        This method use for add task into database.
        It return the task id of new task.
        */
        public static int AddTask(YouCompleteMe.Models.Task task)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string insertStatement =
                "INSERT tasks " +
                  "(task_owner, taskType, title, createdDate, currentDate, deadline, task_priority, completed) " +
                "VALUES (@task_owner, @taskType, @title, @createdDate, @currentDate, @deadline, @task_priority, @completed)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@task_owner", task.task_owner);
            insertCommand.Parameters.AddWithValue("@title", task.title);
            insertCommand.Parameters.AddWithValue("@createdDate", task.createdDate);
            insertCommand.Parameters.AddWithValue("@currentDate", task.currentDate);
            insertCommand.Parameters.AddWithValue("@deadline", task.deadline);
            insertCommand.Parameters.AddWithValue("@task_priority", task.task_priority);
            insertCommand.Parameters.AddWithValue("@completed", task.completed);
            insertCommand.Parameters.AddWithValue("@taskType", task.taskType);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT IDENT_CURRENT('tasks') FROM tasks";
                SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
                int taskID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return taskID;
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


        /*Returns specified task based on taskID */
        public static Models.Task getATask(int taskID)
        {
            Models.Task task = new Models.Task();
            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement = "SELECT * FROM tasks WHERE taskID = @taskID";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

            selectCommand.Parameters.AddWithValue("@taskID", taskID);

            SqlDataReader reader = null;
            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();
                if (reader.Read())
                {
                    task.taskID = Convert.ToInt32(reader["taskID"]);
                    task.taskType = Convert.ToInt32(reader["taskType"]);
                    task.task_owner = Convert.ToInt32(reader["task_owner"]);
                    task.task_priority = Convert.ToInt32(reader["task_priority"]);
                    task.title = reader["title"].ToString();
                    task.currentDate = Convert.ToDateTime(reader["currentDate"]);
                    task.createdDate = Convert.ToDateTime(reader["createdDate"]);
                    task.deadline = Convert.ToDateTime(reader["deadline"]);
                    task.completed = Convert.ToBoolean(reader["completed"]);
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

        // Get all tasks for the current user associated with the selected date
        public static List<Models.Task> getCurrentUsersTasks(User currentUser, string date)
        {
            List<Models.Task> tasks = new List<Models.Task>();

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
                    Models.Task task = new Models.Task();
                    task.task_owner = Convert.ToInt32(reader["task_owner"]);
                    task.taskID = Convert.ToInt32(reader["taskID"]);
                    task.taskType = Convert.ToInt32(reader["taskType"]);
                    task.task_priority = Convert.ToInt32(reader["task_priority"]);
                    //task.completed = Convert.ToInt32(reader["completed"]);
                    task.completed = Convert.ToBoolean(reader["completed"]);
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

        // Only update the task to the currentDate if it is not complete
        public static int updateIncompleteTasksToCurrentDate()
        {
            SqlConnection connection = DBConnection.GetConnection();
            string updateStatement = "UPDATE tasks set " +
                                     "currentDate = GETDATE() " +
                                     "WHERE completed = 0";
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);

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
    }
}
