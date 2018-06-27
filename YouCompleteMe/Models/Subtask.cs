using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouCompleteMe.Models
{
    class Subtask
    {
        public int taskID { get; set; }

        public int subtaskID { get; set; }

        public string st_Description { get; set; }

        public DateTime st_CreatedDate { get; set; }

        public DateTime st_CompleteDate { get; set; }

        public DateTime st_Deadline { get; set; }

        public int st_Priority { get; set; }

        public string note { get; set; }
    }
}
