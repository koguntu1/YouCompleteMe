using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouCompleteMe.DAL;

namespace YouCompleteMe.Controller
{
    public static class UserController
    {
        public static void createUser(string username, string fName, string lName, string email, string phone, string password)
        {
            UserDAL.createUser(username, fName, lName, email, phone, password);
        }
    }
}
