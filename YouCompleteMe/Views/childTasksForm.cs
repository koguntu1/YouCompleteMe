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
    public partial class childTasksForm : Form
    {
        public childTasksForm()
        {
            InitializeComponent();
        }

        private void btnUpdateSubTask_Click(object sender, EventArgs e)
        {
            AddUpdateChildTaskForm addUpdateChildTaskForm = new AddUpdateChildTaskForm();
            addUpdateChildTaskForm.Show();
        }

        private void btnAddNewSubTask_Click(object sender, EventArgs e)
        {
            AddUpdateChildTaskForm addUpdateChildTaskForm = new AddUpdateChildTaskForm();
            addUpdateChildTaskForm.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //search list sub task between from date and to date
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
