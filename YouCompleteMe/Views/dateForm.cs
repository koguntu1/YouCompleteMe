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
    public partial class dateForm : Form
    {
        User user;
        mainForm parentCalendar;
        private static dateForm instance;
        private List<Models.Task> tasks;

        public dateForm(User _user, mainForm _calendar)
        {
            InitializeComponent();
            user = _user;
            this.parentCalendar = _calendar;
            instance = this;
            this.tasks = TaskController.getUserTasks(user, parentCalendar.getSelectedDate());
        }

        public static dateForm Instance
        {
            get
            {
                return instance;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            AddUpdateTaskForm addUpdateTaskForm = new AddUpdateTaskForm(user, true);
            addUpdateTaskForm.ShowDialog();
        }

        private void btnAddNewTask_Click(object sender, EventArgs e)
        {
            AddUpdateTaskForm addUpdateTaskForm = new AddUpdateTaskForm(user,false);
            addUpdateTaskForm.ShowDialog();
        }

        private void tasksBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tasksBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.project6920DataSet);

        }

        // Load with the current users tasks for the selected date
        private void dateForm_Load(object sender, EventArgs e)
        {
            this.label2.Text = parentCalendar.getSelectedDate_Formatted();
            tasksDataGridView.DataSource = TaskController.getCurrentTaskDeadlines(user, parentCalendar.getSelectedDate());
            populateTaskTreeView();
            //populateScheduleListView();

        }

        // When the checkbox is clicked the task will be updated to complete or incomplete, 
        // depending on the current state
        private void tasksDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToInt16(tasksDataGridView.Rows[e.RowIndex].Cells[0].Value) == 0)
                {
                    TaskController.updateTaskCompleted(Convert.ToInt32(tasksDataGridView.Rows[e.RowIndex].Cells[1].Value));
                    tasksDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                else if (Convert.ToInt16(tasksDataGridView.Rows[e.RowIndex].Cells[0].Value) == 1)
                {
                    TaskController.updateTaskIncomplete(Convert.ToInt32(tasksDataGridView.Rows[e.RowIndex].Cells[1].Value));
                    tasksDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        private void populateTaskTreeView()
        {
            //List<Models.Task> tasks = TaskController.getUserTasks(user, parentCalendar.getSelectedDate());
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
                {
                    currentNode.Checked = true;
                }
                // Set font color to indicate priority
                if (task.task_priority == 3)
                {
                    currentNode.ForeColor = Color.Red;
                }
                if (task.task_priority == 2)
                {
                    currentNode.ForeColor = Color.Orange;
                }

                // Add details tooltip
                currentNode.ToolTipText = "Deadline: " + task.deadline.ToString() + "\n" +
                                          "Priority: " + task.task_priority.ToString() + "\n" +
                                          "Notes: " + this.getNoteString(task.taskID, -1);
                taskTreeView.ShowNodeToolTips = true;

                // Get all subtasks for the current task
                List<Subtask> subtasks = SubtaskController.GetSubtasksForTask(user, task.taskID);

                // Add each subtask as a nested node
                foreach(Subtask st in subtasks)
                {
                    currentNode.Nodes.Add(st.st_Description);
                    currentNode.Nodes[subtasks.FindIndex(b => b.subtaskID == st.subtaskID)].Tag = st;

                    // Mark completed subtasks with a checked box
                    if (st.st_CompleteDate != DateTime.MaxValue)
                    {
                        currentNode.Nodes[subtasks.FindIndex(b => b.subtaskID == st.subtaskID)].Checked = true;
                    }  
                }
            }

            taskTreeView.BeforeCheck += taskTreeView_BeforeCheck;
        }

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

        //private void populateScheduleListView()
        //{
        //    //List<string> times = new List<string>()

        //    //{ "00:00", "01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00", "08:00", "09:00", "10:00", "11:00",
        //    //  "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00" };

        //    DateTime date = new DateTime();
        //    var times = Enumerable.Repeat(date, 24).Select((x, i) => x.AddHours(i).ToString("HH"));

        //    List<Models.Task> tasks = TaskController.getUserTasks(user, parentCalendar.getSelectedDate());

        //    deadlineListView.Items.Clear();

        //    foreach (string time in times)
        //    {
        //        ListViewItem lvItem = new ListViewItem(time);
        //        //lvItem.Text = time;

        //        string taskItems = "";
        //        foreach (Models.Task task in tasks)
        //        {
        //            int hour = Convert.ToInt32(task.deadline.ToString("HH"));
        //            if (hour == Convert.ToInt32(time)) //S && task.deadline.Date == Convert.ToDateTime(parentCalendar.getSelectedDate()).Date)
        //            {
        //                taskItems += task.title;
        //            }
        //            lvItem.SubItems.Add(taskItems);
        //        }
        //        deadlineListView.Items.Add(lvItem);
        //    }
        //}

        private string getNoteString(int taskID, int subtaskID)
        {
            string strNotes = "";
            List<Note> notes = NoteController.getNotes(taskID, subtaskID);
            foreach(Note note in notes)
            {
                strNotes += "\n" + note.note_message + "\n";
            }
            return strNotes;
        }
    }
}
