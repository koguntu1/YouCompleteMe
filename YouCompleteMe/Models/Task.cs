using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouCompleteMe.Models
{
    public class Task
    {
        public int task_owner { get; set; }
	    public int taskID { get; set; } 
        public int taskType { get; set; }
	    public string title { get; set; }
	    public DateTime createdDate { get; set; }
        public DateTime currentDate { get; set; }
        public DateTime deadline { get; set; }
        public int task_priority { get; set; }
        public bool completed { get; set; }
        public string note { get; set; }
        public int isMeeting { get; set; }
    }
}
