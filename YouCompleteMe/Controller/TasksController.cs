using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouCompleteMe.DAL;
using YouCompleteMe.Models;

namespace YouCompleteMe.Controller
{
    class TasksController
    { 
        // Update the currentDate field to GETDATE()
        public int updateIncompleteTasksToCurrentDate()
        {
            return TasksDAL.updateIncompleteTasksToCurrentDate();
        }

        // Get list of all tasks for the current user
        public List<TaskModel> getTasksForCurrentUser(User currentUser, string date)
        {
            return TasksDAL.getCurrentUsersTasks(currentUser, date);
        }
    }
}
