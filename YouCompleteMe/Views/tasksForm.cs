using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouCompleteMe.Views
{
    public partial class tasksForm : Form
    {
        public tasksForm()
        {
            InitializeComponent();
        }

        private void btnAddNewTask_Click(object sender, EventArgs e)
        {
            AddUpdateTaskForm addUpdateTaskForm = new AddUpdateTaskForm();
            addUpdateTaskForm.Show();
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            AddUpdateTaskForm addUpdateTaskForm = new AddUpdateTaskForm();
            addUpdateTaskForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //search sub task between from date and to date
        }
    }
}
