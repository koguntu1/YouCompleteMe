using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using YouCompleteMe.Controller;
using YouCompleteMe.Models;

namespace YouCompleteMe.Views
{
    public partial class dateForm : Form
    {
        User user;
        mainForm parentCalendar;
        private static dateForm instance;
        private List<Models.Task> tasks;
        private AddUpdateChildTaskForm subtaskForm;
        private AddMeetingToTasksForm meetingForm;
        private int selectedTask;
        private int timedTaskID;
        private int timerSecs = 0;
        private int seconds = 0;
        private int minutes = 0;

        // Form takes a user and main calendar form objects
        public dateForm(User _user, mainForm _calendar)
        {
            InitializeComponent();
            user = _user;
            this.parentCalendar = _calendar;
            instance = this;
            //this.tasks = TaskController.getUserTasks(user, parentCalendar.getSelectedDate());
        }

        public static dateForm Instance
        {
            get
            {
                return instance;
            }
        }

        // Load form with the current users tasks for the selected date
        public void dateForm_Load(object sender, EventArgs e)
        {
            this.lblDate.Text = parentCalendar.getSelectedDate_Formatted();
            this.taskTreeView.Nodes.Clear();
            this.tasks = TaskController.getUserTasks(user, parentCalendar.getSelectedDate());
            tasksDataGridView.DataSource = TaskController.getCurrentTaskDeadlines(user, parentCalendar.getSelectedDate());
            populateTaskTreeView();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Open update task form
        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            AddUpdateTaskForm addUpdateTaskForm = new AddUpdateTaskForm(user, true, this);
            addUpdateTaskForm.ShowDialog();
        }

        // Open add new task form
        private void btnAddNewTask_Click(object sender, EventArgs e)
        {
            AddUpdateTaskForm addUpdateTaskForm = new AddUpdateTaskForm(user, false, this);
            addUpdateTaskForm.ShowDialog();
        }


        /* Currently unused */
        //private void tasksBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        //{
        //    this.Validate();
        //    this.tasksBindingSource.EndEdit();
        //    this.tableAdapterManager.UpdateAll(this.project6920DataSet);
        //}


        /* 
         * Populate the task tree view with tasks and subtasks
         */
        private void populateTaskTreeView()
        {
            //this.tasks = TaskController.getUserTasks(user, parentCalendar.getSelectedDate());
            taskTreeView.ShowLines = false;
            //taskTreeView.AfterCheck -= taskTreeView_AfterCheck;

            // Add tasks to the list
            foreach (Models.Task task in this.tasks)
            {
                taskTreeView.Nodes.Add(task.title);
                TreeNode currentNode = taskTreeView.Nodes[this.tasks.FindIndex(a => a.taskID == task.taskID)];
                currentNode.Tag = task;

                // Mark complete tasks with a checked box
                if (task.completed == true)
                    currentNode.Checked = true;

                // Set font color to indicate priority
                if (task.task_priority == 1)
                    currentNode.ForeColor = Color.Red;
                else if (task.task_priority == 2)
                    currentNode.ForeColor = Color.Orange;
                if (task.isMeeting == 1)
                    currentNode.ForeColor = Color.Blue;

                // Add details tooltip
                String priority = "";
                if (task.task_priority == -1)
                    priority = "None";
                else if (task.task_priority == 1)
                    priority = "High";
                else if (task.task_priority == 2)
                    priority = "Medium";
                else
                    priority = "Low";

                string deadline = "";
                if (task.deadline == DateTime.MaxValue)
                    deadline = "None";
                else
                    deadline = task.deadline.ToString();
                currentNode.ToolTipText = "Deadline: " + deadline + "\n" +
                                          "Priority: " + priority + "\n" +
                                          "Notes: " + this.getNoteString(task.taskID, -1);
                taskTreeView.ShowNodeToolTips = true;

                // Get all subtasks for the current task
                List<Subtask> subtasks = SubtaskController.GetSubtasksForTask(user, task.taskID);

                // Add each subtask as a nested node
                foreach (Subtask st in subtasks)
                {
                    currentNode.Nodes.Add(st.st_Description);
                    currentNode.Nodes[subtasks.FindIndex(b => b.subtaskID == st.subtaskID)].Tag = st;
                    // Add details tooltip
                    String st_priority = "";
                    if (st.st_Priority == -1)
                        st_priority = "None";
                    else if (st.st_Priority == 1)
                        st_priority = "High";
                    else if (st.st_Priority == 2)
                        st_priority = "Medium";
                    else
                        st_priority = "Low";

                    string subtaskdeadline = "";
                    if (st.st_Deadline == DateTime.MaxValue)
                        subtaskdeadline = "None";
                    else
                        subtaskdeadline = st.st_Deadline.ToString();
                    currentNode.Nodes[subtasks.FindIndex(b => b.subtaskID == st.subtaskID)].ToolTipText = "Deadline: " + subtaskdeadline + "\n" +
                                                                                                          "Priority: " + st_priority + "\n" +
                                                                                                          "Notes: " + this.getNoteString(task.taskID, st.subtaskID);

                    // Mark completed subtasks with a checked box
                    if (st.st_CompleteDate != DateTime.MaxValue)
                    {
                        currentNode.Nodes[subtasks.FindIndex(b => b.subtaskID == st.subtaskID)].Checked = true;
                    }
                }
            }

            taskTreeView.BeforeCheck += taskTreeView_BeforeCheck;
        }

        /*
         * Updates tasks and subtasks to complete or incomplete in the database
         * based on the current checked status
         */
        private void taskTreeView_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            // Check whether the node is a task or a subtask
            // in order to decide which update statements to call
            if (e.Node.Parent == null)
            {
                Models.Task tag = (Models.Task)e.Node.Tag;
                if (e.Node.Checked == false)
                {
                    TaskController.updateTaskCompleted(tag.taskID);
                    List<Subtask> subtasks = SubtaskController.GetSubtasksForTask(user, tag.taskID);
                    foreach (Subtask st in subtasks)
                    {
                        if (st.st_CompleteDate == DateTime.MaxValue)
                            SubtaskController.UpdateSubtaskToCompleted(st.subtaskID);
                    }
                    foreach (TreeNode node in e.Node.Nodes)
                    {
                        node.Checked = true;
                    }
                }
                else if (e.Node.Checked == true)
                {
                    TaskController.updateTaskIncomplete(tag.taskID);
                }
            }
            else
            {
                Subtask subTag = (Subtask)e.Node.Tag;
                if (e.Node.Checked == false)
                {
                    SubtaskController.UpdateSubtaskToCompleted(subTag.subtaskID);
                }
                else if (e.Node.Checked == true)
                {
                    SubtaskController.UpdateSubtaskToIncomplete(subTag.subtaskID);
                }
            }
        }

        /*
         * Gets all notes for the given task or subtask
         */
        private string getNoteString(int taskID, int subtaskID)
        {
            string strNotes = "";
            List<Note> notes = NoteController.getNotes(taskID, subtaskID);
            foreach (Note note in notes)
            {
                strNotes += "\n" + note.note_message + "\n";
            }
            return strNotes;
        }

        /*
         * Opens the add subtask form
         */
        private void btnAddSubtask_Click(object sender, EventArgs e)
        {
            if (taskTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select a task from the Task List.");
            }
            else if (subtaskForm == null)
            {
                //MessageBox.Show(this.getSelectedNodeTaskID().ToString());
                Models.Task tag = (Models.Task)taskTreeView.SelectedNode.Tag;
                //MessageBox.Show(tag.taskID.ToString());
                subtaskForm = new AddUpdateChildTaskForm(user, false, this);
                //childTask.MdiParent = this;
                subtaskForm.StartPosition = FormStartPosition.CenterScreen;
                subtaskForm.FormClosed += SubtaskForm_FormClosed;
                subtaskForm.ShowDialog();
            }
            else
            {
                subtaskForm.Activate();
            }
        }

        private void SubtaskForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            subtaskForm.Dispose();
            subtaskForm = null;
        }

        public int getSelectedNodeTaskID()
        {
            return this.selectedTask;
        }

        private void taskTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                Models.Task tag = (Models.Task)taskTreeView.SelectedNode.Tag;
                this.selectedTask = tag.taskID;
            }
        }

        //////////TIMER//////////

        // Increment the timer label on each tick
        private void taskTimer_Tick(object sender, EventArgs e)
        {
            this.timerSecs++;
            if (seconds < 60)
                seconds++;
            else
            {
                seconds = 0;
                minutes++;
            }
            lblTimer.Refresh();
            lblTimer.Text = String.Format("{0:D2}:{1:D2}", minutes, seconds);
           // lblTimer.Text = String.Format(timerSecs.ToString());
            /* Add code for popup in each 5 mins*/
            int interval = 5;
            if (minutes > 0 && minutes % interval == 0)
            {
                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "Notification";
                popup.ContentText = "You've been on for while! You need a break!!! \nWe will remind you in every 5 mins.";
                popup.Popup();
            }
        }

        // Start timer button should check that a task is selected,
        // set the current task being timed,
        // clear the timer label and start ther timer ticking,
        // and enable the stop button / disable itself
        private void btnStartTimer_Click(object sender, EventArgs e)
        {

            if (taskTreeView.SelectedNode == null || taskTreeView.SelectedNode.Parent != null)
                MessageBox.Show("Please select a task.\nYou can only time top-level tasks (not subtasks).");
            else
            {
                this.timedTaskID = this.getSelectedNodeTaskID();
                lblTimer.Text = "00:00";
                btnStartTimer.Enabled = false;
                btnStopTimer.Enabled = true;
                taskTimer.Start();
                //MessageBox.Show(this.timedTaskID.ToString());
            }
        }

        // Stop timer button should update the database based on the current timer,
        // stop the timer ticking,
        // clear the timerSecs variable for the next timer session,
        // and enable the start button / disable itself
        private void btnStopTimer_Click(object sender, EventArgs e)
        {
            //if (TimerController.checkForTask(timedTaskID) == null)
            TimerController.AddActivity(timedTaskID, timerSecs);
            //else
            //    TimerController.updateTaskAlreadyInActivities(timedTaskID, timerSecs);

            taskTimer.Stop();
            btnStopTimer.Enabled = false;
            btnStartTimer.Enabled = true;
            this.seconds = 0;
            this.minutes = 0;
            this.timerSecs = 0;
        }

        private void cbPersonal_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPersonal.Checked == false)
            {
                List<Models.Task> idsToRemove = TaskController.getTaskOfType(user, parentCalendar.getSelectedDate(), 2);
                foreach (Models.Task task in idsToRemove)
                {
                    this.tasks = this.tasks.Where(tasks => tasks.taskID != task.taskID).ToList();
                }
            }
            else
            {
                List<Models.Task> idsToAdd = TaskController.getTaskOfType(user, parentCalendar.getSelectedDate(), 2);
                foreach (Models.Task task in idsToAdd)
                {
                    this.tasks.Add(task);
                }
            }
            taskTreeView.Nodes.Clear();
            //this.dateForm_Load(sender, e);
            this.populateTaskTreeView();
        }

        private void cbProfessional_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProfessional.Checked == false)
            {
                List<Models.Task> idsToRemove = TaskController.getTaskOfType(user, parentCalendar.getSelectedDate(), 1);
                foreach (Models.Task task in idsToRemove)
                {
                    this.tasks = this.tasks.Where(tasks => tasks.taskID != task.taskID).ToList();
                }
            }
            else
            {
                List<Models.Task> idsToAdd = TaskController.getTaskOfType(user, parentCalendar.getSelectedDate(), 1);
                foreach (Models.Task task in idsToAdd)
                {
                    this.tasks.Add(task);
                }
            }
            taskTreeView.Nodes.Clear();
            //this.dateForm_Load(sender, e);
            this.populateTaskTreeView();
        }

        private void cbOther_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOther.Checked == false)
            {
                List<Models.Task> idsToRemove = TaskController.getTaskOfType(user, parentCalendar.getSelectedDate(), 3);
                foreach (Models.Task task in idsToRemove)
                {
                    this.tasks = this.tasks.Where(tasks => tasks.taskID != task.taskID).ToList();
                }
            }
            else
            {
                List<Models.Task> idsToAdd = TaskController.getTaskOfType(user, parentCalendar.getSelectedDate(), 3);
                foreach (Models.Task task in idsToAdd)
                {
                    this.tasks.Add(task);
                }
            }
            taskTreeView.Nodes.Clear();
            //this.dateForm_Load(sender, e);
            this.populateTaskTreeView();
        }

        private void btnAddMeeting_Click(object sender, EventArgs e)
        {
            if (meetingForm == null)
            {
                meetingForm = new AddMeetingToTasksForm(user, false, this);
                //childTask.MdiParent = this;
                meetingForm.StartPosition = FormStartPosition.CenterScreen;
                meetingForm.FormClosed += MeetingForm_FormClosed;
                meetingForm.ShowDialog();
            }
            else
            {
                meetingForm.Activate();
            }
        }

        private void MeetingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            meetingForm.Dispose();
            meetingForm = null;
        }
    }
}
