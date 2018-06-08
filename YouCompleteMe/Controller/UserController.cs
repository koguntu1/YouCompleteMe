using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouCompleteMe.DAL;
using YouCompleteMe.Models;

namespace YouCompleteMe.Controller
{
    public static class UserController
    {
        public static void createUser(string username, string fName, string lName, string email, string phone, string password)
        {
            UserDAL.createUser(username, fName, lName, email, phone, password);
        }

        public static List<User> getUsers()
        {
            return UserDAL.getUsers();
        }
    }
}
