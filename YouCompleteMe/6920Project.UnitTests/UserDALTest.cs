using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
