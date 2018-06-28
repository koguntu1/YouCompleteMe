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
                if (task.task_priority == 1)
                {
                    currentNode.ForeColor = Color.Red;
                }
                if (task.task_priority == 2)
                {
                    currentNode.ForeColor = Color.Orange;
                }

                // Add details tooltip
                String priority = "";
                if (task.task_priority == 1)
                    priority = "High";
                else if (task.task_priority == 2)
                    priority = "Medium";
                else
                    priority = "Low";
                currentNode.ToolTipText = "Deadline: " + task.deadline.ToString() + "\n" +
                                          "Priority: " + priority + "\n" +
                                          "Notes: " + this.getNoteString(task.taskID, -1);
                taskTreeView.ShowNodeToolTips = true;

                // Get all subtasks for the current task
                List<Subtask> subtasks = SubtaskController.GetSubtasksForTask(user, task.taskID);

                // Add each subtask as a nested node
                foreach(Subtask st in subtasks)
                {
                    currentNode.Nodes.Add(st.st_Description);
                    currentNode.Nodes[subtasks.FindIndex(b => b.subtaskID == st.subtaskID)].Tag = st;
                    // Add details tooltip
                    String st_priority = "";
                    if (st.st_Priority == 1)
                        st_priority = "High";
                    else if (st.st_Priority == 2)
                        st_priority = "Medium";
                    else
                        st_priority = "Low";
                    currentNode.Nodes[subtasks.FindIndex(b => b.subtaskID == st.subtaskID)].ToolTipText = "Deadline: " + st.st_Deadline.ToString() + "\n" +
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

        private void dateForm_Activated(object sender, EventArgs e)
        {
            taskTreeView.Nodes.Clear();
            this.tasks = TaskController.getUserTasks(user, parentCalendar.getSelectedDate());
            dateForm_Load(sender, e);
        }
    }
}
