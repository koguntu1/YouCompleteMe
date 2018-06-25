using System;
using System.Collections.Generic;
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
    }
}
