using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouCompleteMe.DAL;
using YouCompleteMe.Models;

namespace YouCompleteMe.Controller
{
    class NoteController
    {
        public static List<Note> getNotes(int taskID, int subtaskID)
        {
            return NoteDAL.getNotes(taskID, subtaskID);
        }
    }
}
