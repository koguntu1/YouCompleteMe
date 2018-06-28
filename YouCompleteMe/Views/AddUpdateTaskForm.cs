using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
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
        private static AddUpdateTaskForm instance;
        public AddUpdateTaskForm(User _user, bool _isUpdate, dateForm dateForm)
        {
            InitializeComponent();
            user = _user;
            isUpdate = _isUpdate;
            comboPriority.SelectedIndex = 0;
            this.dateForm = dateForm;
            instance = this;
            deadlineDateTimePicker.Format = DateTimePickerFormat.Custom;
            deadlineDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm";
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
            {
                _task.deadline = deadlineDateTimePicker.Value;
            }
            
            _task.task_owner = user.userID;
            if (comboPriority.SelectedItem.ToString() == "")
                _task.task_priority = -1;
            else if (comboPriority.SelectedItem.ToString() == "Low")
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
                        DialogResult result = MessageBox.Show("Do You Want to Add this task to database?", "Create new task", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.OK))
                        {
                            int taskID = TaskController.AddTask(task);
                            MessageBox.Show("Task successfully added");
                            dateForm.dateForm_Load(sender, e);
                            this.Close();
                        }   
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
