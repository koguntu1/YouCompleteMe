using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouCompleteMe.Models
{
    public class CurrentUser
    {
        public static User User { get; private set; }


        public static void setCurrentUser(User user)
        {
            User = user;
        }
    }
}
