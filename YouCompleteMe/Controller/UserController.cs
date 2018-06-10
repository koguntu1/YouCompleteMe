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
        //Calls UserDAL to create a new user
        public static void createUser(string username, string fName, string lName, string email, string phone, 
            string password, string hint)
        {
            UserDAL.createUser(username, fName, lName, email, phone, password, hint);
        }

        //Calls UserDAL to return a list of users
        public static List<User> getUsers()
        {
            return UserDAL.getUsers();
        }

        //Calls UserDAL to return a single user
        public static User getAUser(string username, string password)
        {
            return UserDAL.getAUser(username, password);
        }
    }
}
