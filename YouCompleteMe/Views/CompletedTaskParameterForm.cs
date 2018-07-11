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
    public partial class CompletedTaskParameterForm : Form
    {
        private static CompletedTaskParameterForm instance;
        private static ViewCompletedTasksForm report;
        private static ViewTimeSpentOnTaskForm timeReport;
        private User theUser;

        public CompletedTaskParameterForm(User aUser)
        {
            instance = this;
            theUser = aUser;
            InitializeComponent();
            reset();
        }

        //Return the current instance of this form
        public CompletedTaskParameterForm Instance
        {
            get
            {
                return this;
            }
        }

        private void completedOnClick(object sender, EventArgs e)
        {
            if (report == null)
            {
                report = new ViewCompletedTasksForm(instance, theUser);
                report.StartPosition = FormStartPosition.CenterScreen;
                report.FormClosed += TaskReport_FormClosed;
                report.ShowDialog();
            }
            else
            {
                report.Activate();
            }
        }

        private void cancelOnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        //Helper to reset combo box and dates to default values
        private void reset()
        {
            DateTime date = TaskController.getMinDate(theUser.userID);
            startDate.Value = date;
            endDate.Value = date;
        }

        public DateTime getStart()
        {
            return startDate.Value;
        }

        public DateTime getEnd()
        {
            return endDate.Value;
        }

        public User getUser()
        {
            return theUser;
        }

        //Sets open report form to null and shows this form with selected values reset
        private void TaskReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            report.Dispose();
            report = null;
            reset();
            this.Show();
        }

        private void timeOnClick(object sender, EventArgs e)
        {
            if (report == null)
            {
                timeReport = new ViewTimeSpentOnTaskForm(instance, theUser);
                timeReport.StartPosition = FormStartPosition.CenterScreen;
                timeReport.FormClosed += TimeReport_FormClosed;
                timeReport.ShowDialog();
            }
            else
            {
                timeReport.Activate();
            }
        }

        private void TimeReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            timeReport.Dispose();
            timeReport = null;
            reset();
            this.Show();
        }
    }
}
