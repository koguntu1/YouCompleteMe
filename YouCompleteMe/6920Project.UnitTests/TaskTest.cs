using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouCompleteMe.Controller;
using YouCompleteMe.Models;

namespace _6920Project.UnitTests
{
    [TestClass]
    public class TaskTest
    {
        [TestMethod]
        public void TestAddTask()
        {
            YouCompleteMe.Models.Task task = new YouCompleteMe.Models.Task();
            task.completed = false;
            task.createdDate = DateTime.Now;
            task.currentDate = DateTime.Now;
            task.deadline = DateTime.Now;
            task.taskType = 2;
            task.task_owner = 8;
            task.task_priority = 2;
            task.title = "use for test unit test";
            task.note = "note use for test unit test";

            int taskID = TaskController.AddTask(task);
            Task result = TaskController.getATask(taskID);
            Assert.AreEqual(taskID, result.taskID);

        }

        [TestMethod]
        public void TestGetTaskWithFailData()
        {
            Task result = TaskController.getATask(-1);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestShouldCreateNewTaskWithUndefinedAttributes()
        {
            Task task = new Task();

            Assert.AreEqual(null, task.title);
            Assert.AreEqual(0, task.taskID);
            Assert.AreEqual(0, task.task_owner);
            Assert.AreEqual(0, task.task_priority);
            Assert.AreEqual(0, task.taskType);
            Assert.AreEqual(false, task.completed);

        }

        [TestMethod]
        public void TestShouldCreateNewTestWithDefinedAttributes()
        {
            Task task = new Task();

            task.completed = true;
            task.taskID = 1;
            task.taskType = 1;
            task.task_priority = 1;
            task.title = "test";

            Assert.AreEqual(true, task.completed);
            Assert.AreEqual(1, task.taskID);
            Assert.AreEqual(1, task.taskType);
            Assert.AreEqual(1, task.task_priority);
            Assert.AreEqual("test", task.title);

        }
    }
}
