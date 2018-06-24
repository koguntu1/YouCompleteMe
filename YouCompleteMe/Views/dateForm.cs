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
        homepageForm parentCalendar;
        private static dateForm instance;
        private List<Models.Task> tasks;

        public dateForm(User _user, homepageForm _calendar)
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
            addUpdateTaskForm.Show();
        }

        private void btnAddNewTask_Click(object sender, EventArgs e)
        {
            AddUpdateTaskForm addUpdateTaskForm = new AddUpdateTaskForm(user,false);
            addUpdateTaskForm.Show();
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
            tasksDataGridView.DataSource = TaskController.getUserTasks(user, parentCalendar.getSelectedDate());
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
                taskTreeView.Nodes[this.tasks.FindIndex(a => a.taskID == task.taskID)].Tag = task;

                // Mark complete tasks with a checked box
                if (task.completed == true)
                {
                    taskTreeView.Nodes[this.tasks.FindIndex(a => a.taskID == task.taskID)].Checked = true;
                }
                // Set font color to indicate priority
                if (task.task_priority == 3)
                {
                    taskTreeView.Nodes[this.tasks.FindIndex(a => a.taskID == task.taskID)].ForeColor = Color.Red;
                    //taskTreeView.Nodes[tasks.FindIndex(a => a.taskID == task.taskID)].NodeFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                }
                if (task.task_priority == 2)
                {
                    taskTreeView.Nodes[this.tasks.FindIndex(a => a.taskID == task.taskID)].ForeColor = Color.Orange;
                }

                // Add taskID as Node.Nodes[0] as a hidded node for reference elsewhere
                //taskTreeView.Nodes[tasks.FindIndex(a => a.taskID == task.taskID)].Nodes.Add(task.taskID.ToString());
                //taskTreeView.Nodes[tasks.FindIndex(a => a.taskID == task.taskID)].Nodes[0].IsVisible = false;

                // Get all subtasks for the current task
                List<Subtask> subtasks = SubtaskController.GetSubtasksForTask(user, task.taskID);

                // Add each subtask as a nested node
                foreach(Subtask st in subtasks)
                {
                    taskTreeView.Nodes[this.tasks.FindIndex(a => a.taskID == task.taskID)].Nodes.Add(st.st_Description);

                    // Mark completed subtasks with a checked box
                    if (st.st_CompleteDate != DateTime.MaxValue)
                    {
                        taskTreeView.Nodes[this.tasks.FindIndex(a => a.taskID == task.taskID)].Nodes[subtasks.FindIndex(b => b.subtaskID == st.subtaskID)].Checked = true;
                    }  
                }
            }

            taskTreeView.BeforeCheck += taskTreeView_BeforeCheck;
        }

        private void taskTreeView_BeforeCheck(object sender, TreeViewCancelEventArgs e)
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
    }
}
