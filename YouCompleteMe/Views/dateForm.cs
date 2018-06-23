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

        public dateForm(User _user, homepageForm _calendar)
        {
            InitializeComponent();
            user = _user;
            this.parentCalendar = _calendar;
            instance = this;
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
            List<Models.Task> tasks = TaskController.getUserTasks(user, parentCalendar.getSelectedDate());
            taskTreeView.ShowLines = false;

            foreach(Models.Task task in tasks)
            {
                taskTreeView.Nodes.Add(task.title);
                if (task.completed == true)
                {
                    taskTreeView.Nodes[tasks.FindIndex(a => a.taskID == task.taskID)].Checked = true;
                }
                if (task.task_priority == 3)
                {
                    taskTreeView.Nodes[tasks.FindIndex(a => a.taskID == task.taskID)].ForeColor = Color.Red;
                    //taskTreeView.Nodes[tasks.FindIndex(a => a.taskID == task.taskID)].NodeFont = new Font(label2.Font.Name, FontStyle.Bold);
                }
                if (task.task_priority == 2)
                {
                    taskTreeView.Nodes[tasks.FindIndex(a => a.taskID == task.taskID)].ForeColor = Color.Orange;
                }
                List<Subtask> subtasks = SubtaskController.GetSubtasksForTask(user, task.taskID);
                foreach(Subtask st in subtasks)
                {
                    taskTreeView.Nodes[tasks.FindIndex(a => a.taskID == task.taskID)].Nodes.Add(st.st_Description);
                    if (st.st_CompleteDate != DateTime.MaxValue)
                    {
                        taskTreeView.Nodes[tasks.FindIndex(a => a.taskID == task.taskID)].Nodes[subtasks.FindIndex(b => b.subtaskID == st.subtaskID)].Checked = true;
                    }  
                }
            }
        }
    }
}
