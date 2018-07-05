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
            AddUpdateTaskForm addUpdateTaskForm = new AddUpdateTaskForm(user, false, null);
            addUpdateTaskForm.ShowDialog();
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            AddUpdateTaskForm addUpdateTaskForm = new AddUpdateTaskForm(user, false, null);
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
            if (listTaskGridView.Columns.Count >= 10)
            {
                listTaskGridView.Columns.RemoveAt(9);
            }
            listTaskGridView.DataSource = null;
            listTaskGridView.Rows.Clear();
            listTaskGridView.Refresh();

            try
            {
                if (fromdateTimePicker.Value > todateTimePicker.Value)
                {
                    MessageBox.Show("From Date must be small than To Date");
                }
                else
                {
                    DateTime fromDate = fromdateTimePicker.Value;
                    DateTime toDate = todateTimePicker.Value;
                    bool isCompleted = false;
                    if (completedCheckBox.Checked)
                        isCompleted = true;

                    DataSet ds = TaskController.GetListTaskByCreatedDate(user.userID, fromDate, toDate, isCompleted);
                    if (ds.Tables.Count > 0)
                    {

                        //begin for grid data
                        listTaskGridView.AutoGenerateColumns = true;
                        listTaskGridView.AutoResizeColumns();// = true;
                        listTaskGridView.DataSource = ds.Tables["tasks"];
                        //hide some columns
                        listTaskGridView.Columns[0].Visible = false;
                        listTaskGridView.Columns[1].Visible = false;
                        listTaskGridView.Columns[8].Visible = false;
                        //add button to data grid
                        DataGridViewButtonColumn SubTaskButton = new DataGridViewButtonColumn();
                        SubTaskButton.Name = "";
                        SubTaskButton.Text = "Detail SubTasks";
                        SubTaskButton.UseColumnTextForButtonValue = true;
                        if (listTaskGridView.Columns["Detail SubTasks"] == null)
                        {
                            listTaskGridView.Columns.Insert(9, SubTaskButton);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No task to show. Please try your search again.");
                    }
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
                if (e.ColumnIndex == 9)
                {
                    DataGridViewRow row = this.listTaskGridView.Rows[e.RowIndex];
                    Models.Task task = new Models.Task();
                    task.task_owner = (int)row.Cells["task_owner"].Value;
                    task.taskID = (int)row.Cells["taskID"].Value;
                    task.title = row.Cells["title"].Value.ToString();
                    task.task_priority = (int)row.Cells["task_priority"].Value;
                    task.taskType = (int)row.Cells["taskType"].Value;
                    
                    childTasksForm subTaskView = new childTasksForm(user,task);
                    subTaskView.StartPosition = FormStartPosition.CenterScreen;
                    subTaskView.ShowDialog();
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
                DialogResult result = MessageBox.Show("Do You Want to Delete this task out database?", "Delete task", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    TaskController.deleteTask(id);
                    MessageBox.Show("Task successfully deleted");
                }
            }
            else
            {
                MessageBox.Show("No task selected. Please try your delete again.");
            }
        }
    }
}