using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouCompleteMe.DAL;

namespace YouCompleteMe.Controller
{
    class TaskController
    {
        public static int AddTask(YouCompleteMe.Models.Task task)
        {
            return TaskDAL.AddTask(task);
        }
    }
}
