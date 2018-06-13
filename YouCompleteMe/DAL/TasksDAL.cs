using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                "currentDate = @date and " +
                "completed = 0";

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
                    task.type = Convert.ToInt32(reader["taskType"]);
                    task.priority = Convert.ToInt32(reader["task_priority"]);
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
    }
}
