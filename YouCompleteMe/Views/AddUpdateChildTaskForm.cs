﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouCompleteMe.Controller;
using YouCompleteMe.Models;

namespace YouCompleteMe.Views
{
    public partial class AddUpdateChildTaskForm : Form
    {
        User user; //user object to keep the information of the user are loged in
        bool isUpdate = false;//if we update the subtask, this variable should set to true when update subtask
                              // and set to false if we add new subtask
        string taskTitle = "";

        private dateForm dateForm;
        private childTasksForm childTasksForm;

        private static AddUpdateChildTaskForm instance;

        public AddUpdateChildTaskForm(User _user, bool _isUpdate, dateForm dateForm, childTasksForm childTasksForm)
        {
            InitializeComponent();
            user = _user;
            isUpdate = _isUpdate;
            //load tasks into comboBox
            this.dateForm = dateForm;
            this.childTasksForm = childTasksForm;
            //LoadComboBoxes();
            //comboPriority.SelectedIndex = 0;
            instance = this;
            deadlinePicker.Format = DateTimePickerFormat.Custom;
            deadlinePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            if (dateForm != null)
                this.taskTitle = TaskController.getATask(dateForm.getSelectedNodeTaskID()).title;
            else if (childTasksForm != null)
                this.taskTitle = childTasksForm.getTask().title;
        }

        public static AddUpdateChildTaskForm Instance
        {
            get
            {
                return instance;
            }
        }

        //load the list task into combo Box
        private List<Models.Task> taskList;

        private void LoadComboBoxes()
        {
            try
            {
                //taskList = TaskController.getListTasks(user.userID);
                //MessageBox.Show(dateForm.getSelectedNodeTaskID().ToString());
                //tbTask.Text = TaskController.getATask(dateForm.getSelectedNodeTaskID()).title;
                comboListTask.DataSource = taskList;
                comboListTask.DisplayMember = "title";
                comboListTask.ValueMember = "taskID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /* Put data input into subtask object before added this subtask into database*/
        private void PutSubTask(Models.Subtask _subtask)
        {
            //_subtask.taskID = (int)comboListTask.SelectedValue;
            if (dateForm != null)
                _subtask.taskID = dateForm.getSelectedNodeTaskID();
            else if (childTasksForm != null)
                _subtask.taskID = childTasksForm.getTask().taskID;

            if (completePicker.Enabled == true)
                _subtask.st_CompleteDate = completePicker.Value;
            else
                _subtask.st_CompleteDate = DateTime.MaxValue;

            //_subtask.st_CreatedDate = createDatePicker.Value;
            _subtask.st_CreatedDate = DateTime.Now;

            if (deadlinePicker.Enabled == true)
                _subtask.st_Deadline = deadlinePicker.Value;
            else
                _subtask.st_Deadline = DateTime.MaxValue;
            
            _subtask.st_Description = txtDescription.Text.Trim();

            if (comboPriority.SelectedItem.ToString() == "")
                _subtask.st_Priority = -1;
            else if (comboPriority.SelectedItem.ToString() == "Low")
                _subtask.st_Priority = 1;
            else if (comboPriority.SelectedItem.ToString() == "Medium")
                _subtask.st_Priority = 2;
            else
                _subtask.st_Priority = 3;
            _subtask.note = notesTextBox.Text.Trim();

        }

        /* Check the data if it is valid or not
           return true if valid and false if invalid
        */
        private bool validData()
        {
            if (Validator.IsPresent(txtDescription) && Validator.IsPresent(deadlinePicker) && Validator.IsPresent(createDatePicker) && Validator.IsPresent(notesTextBox) )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //handle the btn submit click
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isUpdate)//add subtask
                {
                    if (validData())
                    {
                        Models.Subtask subtask = new Models.Subtask();
                        this.PutSubTask(subtask);
                        int subtaskID = 0;
                        //DialogResult result = MessageBox.Show("Do you want to add this subtask to the following task:\n" + taskTitle, "Create new subtask", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        //if (result.Equals(DialogResult.OK))
                        //{
                        subtaskID = SubtaskController.AddSubTask(subtask);
                        //if (subtaskID == 0)
                        //   MessageBox.Show("Subtask was not ablet o be added.  Please try again.");
                        if (dateForm != null) 
                            this.dateForm.dateForm_Load(sender, e);
                        if (childTasksForm != null)
                            this.childTasksForm.refreshChildList();
                        this.Close();
                        //}  
                    }
                }
                else //update subtask
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCompleted_CheckedChanged(object sender, EventArgs e)
        {
            completePicker.Enabled = !completePicker.Enabled;
        }

        private void cbDeadline_CheckedChanged(object sender, EventArgs e)
        {
            deadlinePicker.Enabled = !deadlinePicker.Enabled;
        }

        private void AddUpdateChildTaskForm_Load(object sender, EventArgs e)
        {
            tbTask.Text = taskTitle;
            comboPriority.SelectedIndex = 0;
        }
    }
}
