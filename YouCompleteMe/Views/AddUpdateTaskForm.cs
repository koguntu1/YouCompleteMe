using System;
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
    public partial class AddUpdateTaskForm : Form
    {
        User user; //user object to keep the information of the user are loged in
        bool isUpdate = false;//if we update the task, this variable should set to true when update task
                              // and set to false if we add new task
        public AddUpdateTaskForm(User _user, bool _isUpdate)
        {
            InitializeComponent();
            user = _user;
            isUpdate = _isUpdate;
            comboPriority.SelectedIndex = 0;
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

            _task.createdDate = createDateTimePicker.Value;
            if (deadlineDateTimePicker.Text.Trim() != "")
            {
                _task.deadline = deadlineDateTimePicker.Value;
            }

            _task.currentDate = DateTime.Now;
            
            _task.task_owner = user.userID;
            if (comboPriority.SelectedItem.ToString() == "")
                _task.task_priority = -1;
            else
            {
                _task.task_priority = Int32.Parse(comboPriority.Text);
            }

            if (taskTypeComboBox.SelectedItem == null)
                _task.taskType = 3;
            else
            {
                _task.taskType = Int32.Parse(taskTypeComboBox.Text);
            }
            _task.title = txtTitle.Text;
            _task.note = notesTextBox.Text.Trim();

        }

        /* Check the data if it is valid or not
           return true if valid and false if invalid
        */
        private bool validData()
        {
            if (Validator.IsPresent(txtTitle))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Title cannot empty.", "Input Error");
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
                        int taskID = TaskController.AddTask(task);
                        MessageBox.Show("Task successfully added");
                    }
                }
                else //update task
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
    }
}
