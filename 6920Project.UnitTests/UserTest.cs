using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouCompleteMe.Models;

namespace _6920Project.UnitTests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestShouldCreateNewUserWithUndefinedAttributes()
        {
            User user = new User();

            Assert.AreEqual(null, user.fName);
            Assert.AreEqual(null, user.lName);
            Assert.AreEqual(null, user.userName);
            Assert.AreEqual(null, user.email);
            Assert.AreEqual(null, user.phone);
            Assert.AreEqual(null, user.password);
        }

        [TestMethod]
        public void TestShouldCreateNewUserWithDefinedAttributes()
        {
            User user = new User();

            user.fName = "Hayden";
            user.lName = "Smith";
            user.userName = "hs";
            user.phone = "test";
            user.email = "test";
            user.password = "test";

            Assert.AreEqual("Hayden", user.fName);
            Assert.AreEqual("Smith", user.lName);
            Assert.AreEqual("hs", user.userName);
            Assert.AreEqual("test", user.email);
            Assert.AreEqual("test", user.phone);
            Assert.AreEqual("test", user.password);
        }
    }
}
