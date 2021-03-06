﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouCompleteMe.Controller;
using YouCompleteMe.Models;

namespace YouCompleteMe.Views
{
    public partial class AddUpdateTaskForm : Form
    {
        User user; //user object to keep the information of the user are loged in
        bool isUpdate = false;//if we update the task, this variable should set to true when update task
                              // and set to false if we add new task
        private dateForm dateForm;
        private tasksForm tasksForm;
        private static AddUpdateTaskForm instance;
        public AddUpdateTaskForm(User _user, bool _isUpdate, dateForm dateForm, tasksForm tasksForm)
        {
            InitializeComponent();
            user = _user;
            isUpdate = _isUpdate;
            comboPriority.SelectedIndex = 0;
            this.dateForm = dateForm;
            this.tasksForm = tasksForm;
            instance = this;
            deadlineDateTimePicker.Format = DateTimePickerFormat.Custom;
            deadlineDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
        }

        public static AddUpdateTaskForm Instance
        {
            get
            {
                return instance;
            }
        }

        /* Exit button click*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* Put data input into task object before added this task into database*/
        private void PutTask(Models.Task _task)
        {
            if (completedCheckBox.Checked)
            {
                _task.completed = true;
            }
            else
            {
                _task.completed = false;
            }

            //_task.createdDate = createDateTimePicker.Value;
            _task.createdDate = DateTime.Now;
            _task.currentDate = DateTime.Now;

            if (deadlineDateTimePicker.Enabled == true)
                _task.deadline = deadlineDateTimePicker.Value;
            else
                _task.deadline = DateTime.MaxValue;
            
            _task.task_owner = user.userID;
            if (comboPriority.SelectedItem.ToString() == "")
                _task.task_priority = -1;
            else if (comboPriority.SelectedItem.ToString() == "High")
                _task.task_priority = 1;
            else if (comboPriority.SelectedItem.ToString() == "Medium")
                _task.task_priority = 2;
            else
                _task.task_priority = 3;

            if (taskTypeComboBox.SelectedItem == null || taskTypeComboBox.SelectedItem.ToString() == "Other")
                _task.taskType = 3;
            else if (taskTypeComboBox.SelectedItem.ToString() == "Personal")
                _task.taskType = 2;
            else
                _task.taskType = 1;

            _task.title = txtTitle.Text;
            _task.note = notesTextBox.Text.Trim();


        }

        /* Check the data if it is valid or not
           return true if valid and false if invalid
        */
        private bool validData()
        {
            if (Validator.IsPresent(txtTitle) && Validator.IsPresent(notesTextBox))
            {
                return true;
            }
            else
            {
                //MessageBox.Show("Title cannot empty.", "Input Error");
                return false;
            }
        }


        /* Handle the submit button click*/
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isUpdate)//add task
                {
                    if (validData())
                    {
                        Models.Task task = new Models.Task();
                        this.PutTask(task);
                        task.isMeeting = 0;
                        //DialogResult result = MessageBox.Show("Do you want to add this task to your to do list?", "Create New Task", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        //if (result.Equals(DialogResult.OK))
                        //{
                        int taskID = TaskController.AddTask(task);
                        if (taskID == 0)
                            MessageBox.Show("Task was not added.  Please try again.");
                        //Thread.Sleep(5000);
                        if (dateForm != null)
                            dateForm.dateForm_Load(sender, e);
                        else if (tasksForm != null)
                            tasksForm.refreshData();
                        this.Close();
                        //}   
                    }
                }
                else //update task
                {

                }
            }
            catch (Exception ex)
            {
                var st = new StackTrace(ex, true);
        var frame = st.GetFrame(0);
        var line = frame.GetFileLineNumber();
        MessageBox.Show(ex.Message + "\nLine Number: " + line.ToString(), ex.GetType().ToString());
            }
}

        private void cbDeadline_CheckedChanged(object sender, EventArgs e)
        {
            deadlineDateTimePicker.Enabled = !deadlineDateTimePicker.Enabled;
        }
    }
}
