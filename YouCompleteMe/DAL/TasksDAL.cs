using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
