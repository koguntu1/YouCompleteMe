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
    public partial class dateTaskView : Form
    {
        private homepageForm calendarParent;
        private TasksController taskController;

        public dateTaskView(homepageForm calendarParent)
        {
            this.calendarParent = calendarParent;
            this.taskController = new TasksController();
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Loads the task DataGridView 
        // Sets the date label
        private void dateTaskView_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'project6920DataSet.tasks' table. You can move, or remove it, as needed.
            //this.tasksTableAdapter.Fill(this.project6920DataSet.tasks);
            //this.dateLabel.Text = calendarParent.getSelectedDate();
            this.dateLabel.Text = calendarParent.getSelectedDate_Formatted();
            this.populateTaskList();
        }

        // Populates the DataGridView with a sql query as the DataSource
        private void populateTaskList()
        {
            //MessageBox.Show("Selected date: " + calendarParent.getSelectedDate());
            //MessageBox.Show("Current User ID: " + CurrentUser.User.userID.ToString());
            tasksDataGridView.DataSource = taskController.getTasksForCurrentUser(CurrentUser.User, calendarParent.getSelectedDate());
        }

        private void tasksBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tasksBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.project6920DataSet);

        }
        // When a checkbox is checked or unchecked, calls correct update based on previous value.
        private void tasksDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToInt16(tasksDataGridView.Rows[e.RowIndex].Cells[0].Value) == 0)
                {
                    taskController.updateTaskCompleted(Convert.ToInt16(tasksDataGridView.Rows[e.RowIndex].Cells[1].Value));
                    tasksDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                else if (Convert.ToInt16(tasksDataGridView.Rows[e.RowIndex].Cells[0].Value) == 1)
                {
                    taskController.updateTaskIncomplete(Convert.ToInt16(tasksDataGridView.Rows[e.RowIndex].Cells[1].Value));
                    tasksDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }
    }
}
