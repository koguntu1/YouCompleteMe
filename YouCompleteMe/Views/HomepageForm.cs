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
            //dateForm dateForm = new dateForm();
            //dateForm.Show();
            dateTaskView dateView = new dateTaskView(this);
            dateView.Show();
        }

        private void homepageForm_Load(object sender, EventArgs e)
        {
            // Update tasks in the database to the current date
            // only updates incomplete tasks
            tasksController.updateIncompleteTasksToCurrentDate();
        }

        public String getSelectedDate_Formatted()
        {
            return monthCalendar1.SelectionRange.Start.ToString("D");
        }
        public String getSelectedDate()
        {
            return monthCalendar1.SelectionRange.Start.ToShortDateString();
        }
    }
}
