using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouCompleteMe.Models
{
    class Note
    {
        public int taskID { get; set; }

        public int subtaskID { get; set; }

        public int noteID { get; set; }

        public string note_message { get; set; }
    }
}
