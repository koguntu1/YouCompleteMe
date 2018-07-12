using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouCompleteMe.DAL;
using YouCompleteMe.Models;

namespace YouCompleteMe.Controller
{
    public class TaskController
    {
        public static int AddTask(YouCompleteMe.Models.Task task)
        {
            return TaskDAL.AddTask(task);
        }

        public static Models.Task getATask(int taskID)
        {
            return TaskDAL.getATask(taskID);
        }

        //get list of task with owner id
        public static List<Models.Task> getListTasks(int userID)
        {
            return TaskDAL.getListTasks(userID);
        }

        public static List<Models.Task> getUserTasks(User currentUser, string date)
        {
            return TaskDAL.getCurrentUsersTasks(currentUser, date);
        }

        public static List<Models.Task> getTaskOfType(User currentUser, string date, int type)
        {
            return TaskDAL.getTasksOfType(currentUser, date, type);
        }

        public static int updateIncompleteTasksToCurrentDate()
        {
            return TaskDAL.updateIncompleteTasksToCurrentDate();
        }

         public static int updateTaskCompleted(int taskID)
        {
            return TaskDAL.updateTaskCompleted(taskID);
        }

        public static int updateTaskIncomplete(int taskID)
        {
            return TaskDAL.updateTaskIncomplete(taskID);
        }

        public static List<Models.Task> getCurrentTaskDeadlines(User currentUser, string date)
        {
            return TaskDAL.getCurrentDeadlines(currentUser, date);
        }

        /* Add this method to get the list of tasks have created date between fromDate and toDate with completed or not*/
        public static DataSet GetListTaskByCreatedDate(int id, DateTime fromDate, DateTime toDate, bool isCompleted)
        {
            return TaskDAL.GetListTaskByCreatedDate(id, fromDate, toDate, isCompleted);
        }

        /*This method get all task has deadline then set bold in calendar*/
        public static List<DateTime> getAllDeadline(User user)
        {
            return TaskDAL.getAllDeadline(user);
        }

        /*Delete task by task id*/
        public static void deleteTask(int taskID)
        {
            TaskDAL.deleteTask(taskID);
        }

        public static DateTime getMinDate(int id)
        {
            return TaskDAL.getMinDate(id);
        }

        public static List<Models.Task> getTasksCompletedOnTime(int userID)
        {
            return TaskDAL.getTasksCompletedOnTime(userID);
        }

        public static int getTotalTime(int userID)
        {
            return TaskDAL.getTotalTime(userID);
        }

        public static int getTotalEntriesWithTime(int userID)
        {
            return TaskDAL.getTotalEntriesWithTime(userID);
        }

        public static List<Models.Task> getMonthlyUserTasks(User user, string date)
        {
            return TaskDAL.getMonthlyUsersTasks(user, date);
        }

        public static double getTimeSpentOnTask(int taskID)
        {
            return TaskDAL.getTimeSpentOnTask(taskID);
        }

        public static double getAverageTime(int userID)
        {
            return (getTotalTime(userID) / getTotalEntriesWithTime(userID)) / 3600.0;
        }

        public static double getPercent(int userID)
        {
            double total = getListTasks(userID).Count;
            double onTime = getTasksCompletedOnTime(userID).Count;
            double percentage;

            if (total == 0)
            {
                percentage = 0;
            }
            else
            {
                percentage = onTime / total;
            }
            return percentage;
        }
    }
}
