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

        public dateForm(User _user, homepageForm _calendar)
        {
            InitializeComponent();
            user = _user;
            this.parentCalendar = _calendar;
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

        private void dateForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'project6920DataSet.tasks' table. You can move, or remove it, as needed.
            //this.tasksTableAdapter.Fill(this.project6920DataSet.tasks);

            tasksDataGridView.DataSource = TaskController.getUserTasks(user, parentCalendar.getSelectedDate());

        }

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
    }
}
