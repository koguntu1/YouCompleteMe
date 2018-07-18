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
    public partial class childTasksForm : Form
    {
        User user;
        Models.Task task;
        private static childTasksForm instance;

        public childTasksForm(User _user, Models.Task _task)
        {
            InitializeComponent();
            user = _user;
            task = _task;
            if(task != null)
            {
                loadData();
            }
            instance = this;
        }

        public void loadData()
        {
            listSubTaskGridView.DataSource = null;
            listSubTaskGridView.Rows.Clear();
            listSubTaskGridView.Refresh();
            try
            {
                    List<Subtask> listSubTask = SubtaskController.GetSubtasksForTask(user, task.taskID);
                    if (listSubTask.Count > 0)
                    {

                        //begin for grid data
                        listSubTaskGridView.AutoGenerateColumns = true;
                        listSubTaskGridView.AutoResizeColumns();// = true;
                        listSubTaskGridView.DataSource = listSubTask;
                        //hide some columns
                        listSubTaskGridView.Columns[0].Visible = false;
                        listSubTaskGridView.Columns[1].Visible = false;
                        listSubTaskGridView.Columns[8].Visible = false;
                        listSubTaskGridView.Columns[6].Visible = false;
                        

                }
                    else
                    {
                        MessageBox.Show("No subtask to show. Please try your search again.");
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                this.BeginInvoke(new MethodInvoker(Close));
            }
        }

        public void getSearchData()
        {

            listSubTaskGridView.DataSource = null;
            listSubTaskGridView.Rows.Clear();
            listSubTaskGridView.Refresh();

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

                    DataSet ds = SubtaskController.GetListSubTaskByCreatedDate(task.taskID, fromDate, toDate);
                    if (ds.Tables.Count > 0)
                    {

                        //begin for grid data
                        listSubTaskGridView.AutoGenerateColumns = true;
                        listSubTaskGridView.AutoResizeColumns();// = true;
                        listSubTaskGridView.DataSource = ds.Tables["subtask"];
                        //hide some columns
                        listSubTaskGridView.Columns[0].Visible = false;
                        listSubTaskGridView.Columns[1].Visible = false;
                                               
                    }
                    else
                    {
                        MessageBox.Show("No subtask to show. Please try your search again.");
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                this.BeginInvoke(new MethodInvoker(Close));
            }
        }

        public static childTasksForm Instance
        {
            get
            {
                return instance;
            }
        }

        private void btnUpdateSubTask_Click(object sender, EventArgs e)
        {
            AddUpdateChildTaskForm addUpdateChildTaskForm = new AddUpdateChildTaskForm(user, true, null);
            addUpdateChildTaskForm.ShowDialog();
        }

        private void btnAddNewSubTask_Click(object sender, EventArgs e)
        {
            AddUpdateChildTaskForm addUpdateChildTaskForm = new AddUpdateChildTaskForm(user, false, null);
            addUpdateChildTaskForm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //search list sub task between from date and to date
            getSearchData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteSubtask_Click(object sender, EventArgs e)
        {
            if (listSubTaskGridView.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.listSubTaskGridView.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["subtaskID"].Value);
                DialogResult result = MessageBox.Show("Do You Want to Delete this subtask out database?", "Delete subtask", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    SubtaskController.deleteSubTask(id);
                    MessageBox.Show("SubTask successfully deleted");
                }
            }
            else
            {
                MessageBox.Show("No subtask selected. Please try your delete again.");
            }
        }
    }
}
