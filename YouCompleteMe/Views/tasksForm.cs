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
    public partial class tasksForm : Form
    {
        User user;
        private static tasksForm instance;

        public tasksForm(User _user)
        {
            InitializeComponent();
            user = _user;
            instance = this;
        }

        public static tasksForm Instance
        {
            get
            {
                return instance;
            }
        }

        private void btnAddNewTask_Click(object sender, EventArgs e)
        {
            AddUpdateTaskForm addUpdateTaskForm = new AddUpdateTaskForm(user, false, null, this);
            addUpdateTaskForm.ShowDialog();
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            AddUpdateTaskForm addUpdateTaskForm = new AddUpdateTaskForm(user, false, null, this);
            addUpdateTaskForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        public void refreshData()
        {
            //clear data table first
            if (listTaskGridView.Columns.Count >= 13)
            {
                listTaskGridView.Columns.RemoveAt(12);
            }
            listTaskGridView.DataSource = null;
            listTaskGridView.Rows.Clear();
            listTaskGridView.Refresh();

            try
            {
                if (fromdateTimePicker.Value > todateTimePicker.Value)
                {
                    MessageBox.Show("Start date must come before end date.");
                }
                else
                {
                    DateTime fromDate = fromdateTimePicker.Value;
                    DateTime toDate = todateTimePicker.Value;
                    bool isCompleted = false;
                    if (completedCheckBox.Checked)
                        isCompleted = true;

                    DataSet ds = TaskController.GetListTaskByCreatedDate(user.userID, fromDate, toDate, isCompleted);

                    //begin for grid data
                    listTaskGridView.AutoGenerateColumns = true;
                    listTaskGridView.AutoResizeColumns();// = true;
                    listTaskGridView.DataSource = ds.Tables["tasks"];

                    //hide some columns
                    listTaskGridView.Columns[0].Visible = false;
                    listTaskGridView.Columns[1].Visible = false;
                    listTaskGridView.Columns[2].Visible = false;
                    listTaskGridView.Columns[7].Visible = false;
                    listTaskGridView.Columns[8].Visible = false;
                    //add button to data grid
                    DataGridViewButtonColumn SubTaskButton = new DataGridViewButtonColumn();
                    SubTaskButton.Name = "";
                    SubTaskButton.Text = "Detail SubTasks";
                    SubTaskButton.UseColumnTextForButtonValue = true;
                    if (listTaskGridView.Columns["Detail SubTasks"] == null)
                    {
                        listTaskGridView.Columns.Insert(12, SubTaskButton);
                    }

                    //if (ds.Tables.Count > 0)
                    //{
                    //    MessageBox.Show("No task to show. Please try a different date range.");
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                this.BeginInvoke(new MethodInvoker(Close));
            }
        }

        private void listTaskGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 12)
                {
                    
                    DataGridViewRow row = this.listTaskGridView.Rows[e.RowIndex];
                    Models.Task task = new Models.Task();
                    task.task_owner = (int)row.Cells["task_owner"].Value;
                    task.taskID = (int)row.Cells["taskID"].Value;
                    task.title = row.Cells["title"].Value.ToString();
                    if (row.Cells["task_priority"].Value == DBNull.Value)
                        task.task_priority = -1;
                    else
                        task.task_priority = Convert.ToInt32(row.Cells["task_priority"].Value);
                    if (row.Cells["taskType"].Value == DBNull.Value)
                        task.taskType = -1;
                    else
                        task.taskType = Convert.ToInt32(row.Cells["taskType"].Value);
                    if (SubtaskController.GetSubtasksForTask(user, task.taskID).Count > 0)
                    {
                        childTasksForm subTaskView = new childTasksForm(user, task);
                        subTaskView.StartPosition = FormStartPosition.CenterScreen;
                        subTaskView.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("This task does not have any subtasks.");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (listTaskGridView.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.listTaskGridView.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["taskID"].Value);
                DialogResult result = MessageBox.Show("Do you want to delete this task?", "Delete task", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    TaskController.deleteTask(id);
                    refreshData();
                }
            }
            else
            {
                MessageBox.Show("No task selected. Please try again.");
            }
        }
    }
}