using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouCompleteMe.DAL;

namespace YouCompleteMe.Controller
{
    public class SubTaskController
    {
        /*
       This method use for add subtask into database.
       It return the subtask id of new subtask.
       */
        public static int AddSubTask(YouCompleteMe.Models.SubTask subtask)
        {
            return SubTaskDAL.AddSubTask(subtask);
        }

        /*Returns specified subtask based on subtaskID */
        public static Models.SubTask getASubTask(int subtaskID)
        {
            return SubTaskDAL.getASubTask(subtaskID);
        }
    }
}
}
