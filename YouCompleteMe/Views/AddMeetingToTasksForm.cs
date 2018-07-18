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
    public partial class AddMeetingToTasksForm : Form
    {
        bool isUpdate;
        User user;
        dateForm dateForm;

        public AddMeetingToTasksForm(User _user, bool _isUpdate, dateForm _dateForm)
        {
            InitializeComponent();
            this.user = _user;
            this.isUpdate = _isUpdate;
            this.dateForm = _dateForm;
            deadlineDateTimePicker.Format = DateTimePickerFormat.Custom;
            deadlineDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isUpdate)//add task
                {
                    if (txtTitle.Text != "" && deadlineDateTimePicker.Text != "")
                    {
                        Models.Task task = new Models.Task();
                        task.task_owner = user.userID;
                        task.createdDate = DateTime.Now;
                        task.currentDate = Convert.ToDateTime(deadlineDateTimePicker.Text);
                        task.completed = false;
                        task.note = notesTextBox.Text.Trim();

                        task.title = txtTitle.Text;
                        try
                        {
                            task.deadline = Convert.ToDateTime(deadlineDateTimePicker.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Please select a valid date and time for the meeting time.");
                        }
                        task.taskType = 4;
                        task.isMeeting = 1;
                        DialogResult result = MessageBox.Show("Do you want to add this meeting to your schedule?", "Add Meeting", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.OK))
                        {
                            int taskID = TaskController.AddTask(task);
                            if (taskID == 0)
                                MessageBox.Show("Meeting was not added.  Please try again.");
                            //Thread.Sleep(5000);
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
    }
}
