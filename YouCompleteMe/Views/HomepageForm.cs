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

namespace YouCompleteMe.Views
{
    public partial class homepageForm : Form
    {
        TasksController tasksController = new TasksController();

        public homepageForm()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            dateForm dateForm = new dateForm();
            dateForm.Show();
        }

        private void homepageForm_Load(object sender, EventArgs e)
        {
            tasksController.updateIncompleteTasksToCurrentDate();
        }
    }
}
