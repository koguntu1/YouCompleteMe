using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouCompleteMe.Models;

namespace YouCompleteMe.DAL
{
    class NoteDAL
    {
        public static List<Note> getNotes(int taskID, int subtaskID)
        {
            List<Note> notes = new List<Note>();

            SqlConnection connection = DBConnection.GetConnection();
            string selectStatement =
                "SELECT * FROM note " +
                "WHERE " +
                "taskID = @taskID or " +
                "(subtaskID = @stID and subtaskID is not null)"; ;

            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@taskID", taskID);
            selectCommand.Parameters.AddWithValue("@stID", subtaskID);

            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Note note = new Note();
                    note.taskID = Convert.ToInt32(reader["taskID"]);
                    if (reader["subtaskID"] == DBNull.Value)
                        note.subtaskID = 0;
                    else
                        note.subtaskID = Convert.ToInt32(reader["subtaskID"]);
                    note.noteID = Convert.ToInt32(reader["noteID"]);
                    note.note_message = reader["note_message"].ToString();

                    notes.Add(note);
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

            return notes;
        }
    }
}
