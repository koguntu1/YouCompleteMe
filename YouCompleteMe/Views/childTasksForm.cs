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
        private static childTasksForm instance;

        public childTasksForm(User _user)
        {
            InitializeComponent();
            user = _user;
            instance = this;
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
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
