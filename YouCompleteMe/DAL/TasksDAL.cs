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

        // Get all tasks for the current user
        public static List<FurnitureListing> getAllCategories()
        {
            List<FurnitureListing> listing = new List<FurnitureListing>();

            SqlConnection connection = RentalDBA.GetConnection();
            string selectStatement =
                "SELECT DISTINCT categoryName " +
                "FROM category ";

            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    FurnitureListing aListing = new FurnitureListing();
                    aListing.category = reader["categoryName"].ToString();
                    listing.Add(aListing);
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

            return listing;
        }
    }
}
