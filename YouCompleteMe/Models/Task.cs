using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouCompleteMe.Models
{
    class Task
    {
        public int task_owner { get; set; }

        public int taskID { get; set; }

        public int type { get; set; }

        public string title { get; set; }

        public int priority { get; set; }

        public int completed { get; set; }

        public DateTime createdDate { get; set; }

        public DateTime currentDate { get; set; }

        public DateTime deadline { get; set; }
    }
}
