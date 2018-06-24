using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouCompleteMe.Controller;
using YouCompleteMe.DAL;
using YouCompleteMe.Models;

namespace _6920Project.UnitTests
{
    [TestClass]
    public class UserDALTest
    {

        [TestMethod]
        public void TestShouldReturnListOfUsers()
        {
            List<User> users = new List<User>();

            Assert.AreEqual(0, users.Count);

            users = UserDAL.getUsers();

            Assert.AreNotEqual(0, users.Count);
        }

        [TestMethod]
        public void TestShouldReturnNullUser()
        {
            CurrentUser.setCurrentUser(UserController.getAUser("a", "a"));

            Assert.AreEqual(null, CurrentUser.User);
        }

        [TestMethod]
        public void TestShouldReturnNullUserWithBadUserName()
        {
            CurrentUser.setCurrentUser(UserController.getAUser("a", "test"));

            Assert.AreEqual(null, CurrentUser.User);
        }

        [TestMethod]
        public void TestShouldReturnNullUserWithBadPassword()
        {
            CurrentUser.setCurrentUser(UserController.getAUser("test", "a"));

            Assert.AreEqual(null, CurrentUser.User);
        }

        [TestMethod]
        public void TestShouldReturnCorrectUser()
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes("Password2@");
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);
            CurrentUser.setCurrentUser(UserController.getAUser("tuser1", hash));
            
            Assert.AreEqual("Test", CurrentUser.User.fName);
            Assert.AreEqual("User", CurrentUser.User.lName);
            Assert.AreEqual("tuser1@gmail.com", CurrentUser.User.email);
            Assert.AreEqual("(678)850-0797", CurrentUser.User.phone);
        }
    }
}
