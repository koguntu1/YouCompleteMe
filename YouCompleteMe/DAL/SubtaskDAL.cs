using System;
using System.Collections.Generic;
using System.Data;
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
                    if (reader["st_Priority"] != DBNull.Value)
                    {
                        subtask.st_Priority = Convert.ToInt32(reader["st_Priority"]);
                        if(subtask.st_Priority == 1)
                        {
                            subtask.Priority = "High";
                        }
                        else if (subtask.st_Priority == 2)
                        {
                            subtask.Priority = "Medium";
                        }
                        else
                        {
                            subtask.Priority = "Low";
                        }

                    }
                    else
                        subtask.st_Priority = -1;

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

        /*
        This method use for add subtask into database.
        It return the subtask id of new subtask.
        */
        public static int AddSubTask(YouCompleteMe.Models.Subtask subtask)
        {
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            SqlTransaction sqlTransaction = connection.BeginTransaction();
            string insertStatement = "INSERT subtask " +
                                     "(taskID, st_Description, st_CreatedDate, st_CompleteDate, st_Deadline, st_Priority) " +
                                     "VALUES (@taskID, @st_Description, @st_CreatedDate, @st_CompleteDate, @st_Deadline, @st_Priority)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection, sqlTransaction);
            insertCommand.Parameters.AddWithValue("@taskID", subtask.taskID);
            insertCommand.Parameters.AddWithValue("@st_Description", subtask.st_Description);
            insertCommand.Parameters.AddWithValue("@st_CreatedDate", subtask.st_CreatedDate);
            if (subtask.st_CompleteDate == DateTime.MaxValue)
            {
                insertCommand.Parameters.AddWithValue("@st_CompleteDate", DBNull.Value);
            }
            else
            {
                insertCommand.Parameters.AddWithValue("@st_CompleteDate", subtask.st_CompleteDate);
            }

            if (subtask.st_Deadline == DateTime.MaxValue)
            {
                insertCommand.Parameters.AddWithValue("@st_Deadline", DBNull.Value);
            }
            else
            {
                insertCommand.Parameters.AddWithValue("@st_Deadline", subtask.st_Deadline);
            }

            if (subtask.st_Priority == -1)
            {
                insertCommand.Parameters.AddWithValue("@st_Priority", DBNull.Value);
            }
            else
            {
                insertCommand.Parameters.AddWithValue("@st_Priority", subtask.st_Priority);
            }

            try
            {

                insertCommand.ExecuteNonQuery();
                string selectStatement = "SELECT IDENT_CURRENT('subtask') FROM subtask";
                SqlCommand selectCommand = new SqlCommand(selectStatement, connection, sqlTransaction);
                int subtaskID = Convert.ToInt32(selectCommand.ExecuteScalar());
                //add notes to notes table
                if (subtask.note != "")
                {
                    string insertNoteStatement = "INSERT note " +
                                             "(taskID, subtaskID, note_message) " +
                                             "VALUES (@taskID, @subtaskID, @note_message)";
                
                    SqlCommand insertNoteCommand = new SqlCommand(insertNoteStatement, connection, sqlTransaction);
                    insertNoteCommand.Parameters.AddWithValue("@taskID", subtask.taskID);
                    insertNoteCommand.Parameters.AddWithValue("@note_message", subtask.note);
                    insertNoteCommand.Parameters.AddWithValue("@subtaskID", subtaskID);
                    insertNoteCommand.ExecuteNonQuery();
                }
                sqlTransaction.Commit();
                return subtaskID;
            }
            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }


        /*Returns specified subtask based on subtaskID */
        public static Models.Subtask getASubTask(int subtaskID)
        {
            Models.Subtask subtask = new Models.Subtask();
            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement = "SELECT * FROM subtask WHERE subtaskID = @subtaskID";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

            selectCommand.Parameters.AddWithValue("@subtaskID", subtaskID);

            SqlDataReader reader = null;
            try
            {
                connection.Open();
                reader = selectCommand.ExecuteReader();
                if (reader.Read())
                {
                    subtask.taskID = Convert.ToInt32(reader["taskID"]);
                    subtask.subtaskID = Convert.ToInt32(reader["subtaskID"]);
                    //subtask.st_Priority = Convert.ToInt32(reader["st_Priority"]);
                    subtask.st_Description = reader["st_Description"].ToString();
                    //subtask.st_Deadline = Convert.ToDateTime(reader["st_Deadline"]);
                    subtask.st_CreatedDate = Convert.ToDateTime(reader["st_CreatedDate"]);
                    //subtask.st_CompleteDate = Convert.ToDateTime(reader["st_CompleteDate"]);
                }
               else
                {
                    subtask = null;
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
            return subtask;
        }

        /* Add this method to get the list of subtasks have taskID and created date between fromDate and toDate*/
        public static DataSet GetListSubTaskByCreatedDate(int taskID,DateTime fromDate, DateTime toDate)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement =
                "SELECT * FROM subtask where (st_CreatedDate between @fromDate and @toDate) and taskID = @taskID";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@fromDate", fromDate);
            selectCommand.Parameters.AddWithValue("@toDate", toDate);
            selectCommand.Parameters.AddWithValue("@taskID", taskID);
            // Create a new data adapter based on the specified query.
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectStatement, connection);
            // Populate a new data table
            DataSet dataSet = new DataSet();
            try
            {
                connection.Open();
                SqlDataReader sdr = selectCommand.ExecuteReader();
                dataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataSet.Tables.Add("subtask");

                //Load DataReader into the DataTable.
                dataSet.Tables[0].Load(sdr);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return dataSet;
        }

        /*Delete subtask by subtask id*/
        public static void deleteSubTask(int subtaskID)
        {
            SqlConnection connection = DBConnection.GetConnection();
            string deleteStatement = "DELETE FROM subtask " +
                                     "WHERE subtaskID = @subtaskID";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@subtaskID", subtaskID);

            SqlDataReader reader = null;
            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
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
