using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouCompleteMe.Models;

namespace YouCompleteMe.Views
{
    public partial class childTasksForm : Form
    {
        User user;
        public childTasksForm(User _user)
        {
            InitializeComponent();
            user = _user;
        }

        private void btnUpdateSubTask_Click(object sender, EventArgs e)
        {
            AddUpdateChildTaskForm addUpdateChildTaskForm = new AddUpdateChildTaskForm(user, true);
            addUpdateChildTaskForm.Show();
        }

        private void btnAddNewSubTask_Click(object sender, EventArgs e)
        {
            AddUpdateChildTaskForm addUpdateChildTaskForm = new AddUpdateChildTaskForm(user, false);
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
