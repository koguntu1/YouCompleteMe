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
    public partial class dateForm : Form
    {
        public dateForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            AddUpdateTaskForm addUpdateTaskForm = new AddUpdateTaskForm();
            addUpdateTaskForm.Show();
        }

        private void btnAddNewTask_Click(object sender, EventArgs e)
        {
            AddUpdateTaskForm addUpdateTaskForm = new AddUpdateTaskForm();
            addUpdateTaskForm.Show();
        }
    }
}
