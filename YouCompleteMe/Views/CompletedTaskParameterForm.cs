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

        private void submitOnClick(object sender, EventArgs e)
        {
            try
            {
                if (report == null)
                {
                    report = new ViewCompletedTasksForm(this);
                    report.FormClosed += new FormClosedEventHandler(TaskReport_FormClosed);
                    report.StartPosition = FormStartPosition.CenterScreen;
                    this.Hide();
                    report.Show();
                }
                else
                {
                    report.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelOnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        //Helper to reset combo box and dates to default values
        private void reset()
        {
            startDate.Value = TaskController.getMinDate(theUser.userID);
            endDate.Value = TaskController.getMinDate(theUser.userID);
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
    }
}
