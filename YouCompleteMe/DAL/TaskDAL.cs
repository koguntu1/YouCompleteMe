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
    }
}
