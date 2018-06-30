using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouCompleteMe.DAL;

namespace YouCompleteMe.Controller
{
    class TimerController
    {
        public static Models.Task checkForTask(int taskID)
        {
            return TimerDAL.checkForTask(taskID);
        }

        public static int updateTaskAlreadyInActivities(int taskID, int timerSecs)
        {
            return TimerDAL.updateTaskAlreadyInActivities(taskID, timerSecs);
        }

        public static int AddActivity(int taskID, int timerSecs)
        {
            return TimerDAL.AddActivity(taskID, timerSecs);
        }
    }
}
