using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouCompleteMe.DAL;
using YouCompleteMe.Models;

namespace YouCompleteMe.Controller
{
    class SubtaskController
    {

        public static List<Subtask> GetSubtasksForTask(User currentUser, int taskID)
        {
            return SubtaskDAL.getSubtasksForTask(currentUser, taskID);
        }

        public static int UpdateSubtaskToCompleted(int subtaskID)
        {
            return SubtaskDAL.updateSubtaskCompleted(subtaskID);
        }

        public static int UpdateSubtaskToIncomplete(int subtaskID)
        {
            return SubtaskDAL.updateSubtaskIncomplete(subtaskID);
        }

        /*
       This method use for add subtask into database.
       It return the subtask id of new subtask.
       */
        public static int AddSubTask(YouCompleteMe.Models.Subtask subtask)
        {
            return SubtaskDAL.AddSubTask(subtask);
        }

        /*Returns specified subtask based on subtaskID */
        public static Models.Subtask getASubTask(int subtaskID)
        {
            return SubtaskDAL.getASubTask(subtaskID);
        }
    }
}
