using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouCompleteMe.DAL;

namespace YouCompleteMe.Controller
{
    class TasksController
    {
       // private TasksDAL tasksDAL = new TasksDAL();
        public int updateIncompleteTasksToCurrentDate()
        {
            return TasksDAL.updateIncompleteTasksToCurrentDate();
        }
    }
}
