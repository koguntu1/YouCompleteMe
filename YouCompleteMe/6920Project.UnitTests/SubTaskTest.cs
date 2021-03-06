﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouCompleteMe.Controller;
using YouCompleteMe.Models;

namespace _6920Project.UnitTests
{
    [TestClass]
    public class SubTaskTest
    {
        [TestMethod]
        public void TestAddSubTask()
        {
            YouCompleteMe.Models.Subtask subtask = new YouCompleteMe.Models.Subtask();
            subtask.taskID = 33;
            subtask.st_CreatedDate = DateTime.Now;
            subtask.st_Deadline = DateTime.Now;
            subtask.st_CompleteDate = DateTime.Now;
            subtask.st_Priority = 2;
            subtask.st_Description = "use for test unit test";
            subtask.note = "this use only for unit test";

            int subtaskID = SubtaskController.AddSubTask(subtask);
            YouCompleteMe.Models.Subtask result = SubtaskController.getASubTask(subtaskID);
            Assert.AreEqual(subtaskID, result.subtaskID);

        }

        [TestMethod]
        public void TestGetSubTaskWithFailData()
        {
            Subtask result = SubtaskController.getASubTask(-1);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestShouldCreateNewSubTaskWithUndefinedAttributes()
        {
            Subtask subtask = new Subtask();

            Assert.AreEqual(null, subtask.st_Description);
            Assert.AreEqual(0, subtask.taskID);
            Assert.AreEqual(0, subtask.subtaskID);
            Assert.AreEqual(0, subtask.st_Priority);

        }

        [TestMethod]
        public void TestShouldCreateNewTestWithDefinedAttributes()
        {
            Subtask subtask = new Subtask();

            subtask.taskID = 33;
            subtask.st_Priority = 2;
            subtask.st_Description = "use for test unit test";
            subtask.note = "this use only for unit test";

            Assert.AreEqual(2, subtask.st_Priority);
            Assert.AreEqual(33, subtask.taskID);
            Assert.AreEqual("use for test unit test", subtask.st_Description);
            Assert.AreEqual("this use only for unit test", subtask.note);

        }
    }
}
