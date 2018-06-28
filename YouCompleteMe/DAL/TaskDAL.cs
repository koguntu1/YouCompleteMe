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
            connection.Open();
            //SqlTransaction sqlTransaction = connection.BeginTransaction();
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
                
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT IDENT_CURRENT('tasks') FROM tasks";
                SqlCommand selectCommand = new SqlCommand(selectStatement, connection);//, sqlTransaction);
                int taskID = Convert.ToInt32(selectCommand.ExecuteScalar());
                string insertNoteStatement = "INSERT note " +
                                             "(taskID, subtaskID, note_message) " +
                                             "VALUES (@taskID, @subtaskID, @note_message)";
                SqlCommand insertNoteCommand = new SqlCommand(insertNoteStatement, connection);//, sqlTransaction);
                insertNoteCommand.Parameters.AddWithValue("@taskID", taskID);
                insertNoteCommand.Parameters.AddWithValue("@note_message", task.note);
                insertNoteCommand.Parameters.AddWithValue("@subtaskID", DBNull.Value);
                insertNoteCommand.ExecuteNonQuery();
                //sqlTransaction.Commit();
                return taskID;
            }
            catch (SqlException ex)
            {
                //sqlTransaction.Rollback();
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
                reader = selectCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    task.taskID = Convert.ToInt32(reader["taskID"]);
                    task.taskType = Convert.ToInt32(reader["taskType"]);
                    task.task_owner = Convert.ToInt32(reader["task_owner"]);
                    task.task_priority = Convert.ToInt32(reader["task_priority"]);
                    task.title = reader["title"].ToString();
                    task.currentDate = Convert.ToDateTime(reader["currentDate"]);
                    task.createdDate = Convert.ToDateTime(reader["createdDate"]);
                    if (reader["deadline"] == DBNull.Value)
                        task.deadline = DateTime.MaxValue;
                    else
                        task.deadline = (DateTime)reader["deadline"];
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

        /* This method get the list of task of a user */
        public static List<Models.Task> getListTasks(int userID)
        {
            List<Models.Task> tasks = new List<Models.Task>();
            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement = "SELECT * " +
                "FROM tasks WHERE task_owner = @userID ";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@userID", userID);
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Models.Task task = new Models.Task();

                    task.task_owner = Convert.ToInt32(reader["task_owner"]);
                    task.taskID = Convert.ToInt32(reader["taskID"]);
                    task.taskType = Convert.ToInt32(reader["taskType"]);
                    //task.task_priority = Convert.ToInt32(reader["task_priority"]);
                    task.title = reader["title"].ToString();
                    task.completed = Convert.ToBoolean(reader["completed"]);
                    task.createdDate = Convert.ToDateTime(reader["createdDate"]);
                    task.currentDate = Convert.ToDateTime(reader["currentDate"]);
                    //task.deadline = Convert.ToDateTime(reader["deadline"]);

                    tasks.Add(task);
                }
                reader.Close();
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
            return tasks;
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
                    if (reader["deadline"] == DBNull.Value)
                        task.deadline = DateTime.MaxValue;
                    else
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

        public static List<Models.Task> getTaskDeadline(int taskID)
        {
            List<Models.Task> tasks = new List<Models.Task>();

            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement =
                "SELECT taskID, deadline FROM tasks " +
                "WHERE " +
                "taskID = @taskID";

            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@taskID", taskID);

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
                    if (reader["deadline"] == DBNull.Value)
                        task.deadline = DateTime.MaxValue;
                    else
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

        public static List<Models.Task> getCurrentDeadlines(User currentUser, string date)
        {
            List<Models.Task> tasks = new List<Models.Task>();

            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement =
                "SELECT * FROM tasks " +
                "WHERE " +
                "task_owner = @user and " +
                "cast(deadline as date) = @date " +
                "order by deadline";

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
                    if (reader["deadline"] == DBNull.Value)
                        task.deadline = DateTime.MaxValue;
                    else
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
