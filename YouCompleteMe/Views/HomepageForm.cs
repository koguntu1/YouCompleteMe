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
            // only updates incomplete tasks (completed = 0)
            tasksController.updateIncompleteTasksToCurrentDate();
        }

        // Returns a date formatted like "Wednesday, June 13, 2018"
        // Used for display purposes
        public String getSelectedDate_Formatted()
        {
            return monthCalendar1.SelectionRange.Start.ToString("D");
        }

        // Returns a date formatted in short date form, like "6/13/2018"
        // Works for SQL queries that match on date if you case the SQL datetime as date
        public String getSelectedDate()
        {
            return monthCalendar1.SelectionRange.Start.ToShortDateString();
        }
    }
}
