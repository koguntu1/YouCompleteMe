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
    }
}
