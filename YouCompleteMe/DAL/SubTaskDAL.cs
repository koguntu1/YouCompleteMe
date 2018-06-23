using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouCompleteMe.DAL
{
    public class SubTaskDAL
    {
        /*
        This method use for add subtask into database.
        It return the subtask id of new subtask.
        */
        public static int AddSubTask(YouCompleteMe.Models.SubTask subtask)
        {
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            SqlTransaction sqlTransaction = connection.BeginTransaction();
            string insertStatement =
                "INSERT subtask " +
                  "(taskID, st_Description, st_CreatedDate, st_CompleteDate, st_Deadline, st_Priority) " +
                "VALUES (@taskID, @st_Description, @st_CreatedDate, @st_CompleteDate, @st_Deadline, @st_Priority)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection, sqlTransaction);
            insertCommand.Parameters.AddWithValue("@taskID", subtask.taskID);
            insertCommand.Parameters.AddWithValue("@st_Description", subtask.st_Description);
            insertCommand.Parameters.AddWithValue("@st_CreatedDate", subtask.st_CreatedDate);
            if(subtask.st_CompleteDate == DateTime.MinValue)
            {
                insertCommand.Parameters.AddWithValue("@st_CompleteDate", DBNull.Value);
            }
            else {
                insertCommand.Parameters.AddWithValue("@st_CompleteDate", subtask.st_CompleteDate);
            }

            if (subtask.st_Deadline == DateTime.MinValue)
            {
                insertCommand.Parameters.AddWithValue("@st_Deadline", DBNull.Value);
            }
            else
            {
                insertCommand.Parameters.AddWithValue("@st_Deadline", subtask.st_Deadline);
            }

            if(subtask.st_Priority == -1)
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
                string selectStatement =
                    "SELECT IDENT_CURRENT('subtask') FROM subtask";
                SqlCommand selectCommand = new SqlCommand(selectStatement, connection, sqlTransaction);
                int subtaskID = Convert.ToInt32(selectCommand.ExecuteScalar());
                //add notes to notes table
                string insertNoteStatement =
                    "INSERT note " +
                      "(taskID, subtaskID, note_message) " +
                    "VALUES (@taskID, @subtaskID, @note_message)";
                SqlCommand insertNoteCommand = new SqlCommand(insertNoteStatement, connection, sqlTransaction);
                insertNoteCommand.Parameters.AddWithValue("@taskID", subtask.taskID);
                insertNoteCommand.Parameters.AddWithValue("@note_message", subtask.note);
                insertNoteCommand.Parameters.AddWithValue("@subtaskID", subtaskID);
                insertNoteCommand.ExecuteNonQuery();
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
        public static Models.SubTask getASubTask(int subtaskID)
        {
            Models.SubTask subtask = new Models.SubTask();
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
                    subtask.st_Priority = Convert.ToInt32(reader["st_Priority"]);
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
    }
}
