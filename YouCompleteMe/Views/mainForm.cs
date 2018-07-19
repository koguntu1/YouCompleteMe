using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using YouCompleteMe.Controller;
using YouCompleteMe.Models;

namespace YouCompleteMe.Views
{
    public partial class mainForm : Form
    {
        private static mainForm instance;
        private static loginForm loginForm;
        //private static homepageForm homepage;
        private static AddUpdateAccountForm addUpdateAccount;
        private static AddUpdateChildTaskForm updateChildTask;
        private static AddUpdateTaskForm updateTask;
        
        private changePasswordForm changePasswordForm;
        private static dateForm dateForm;
        private static tasksForm task;
        private static childTasksForm childTask;
        private static CompletedTaskParameterForm taskParameter;

        private User theUser;

        public mainForm(User _user)
        {
            instance = this;
            InitializeComponent();
            /*Begin change here*/
            theUser = _user;
            if (theUser != null)
            {
                uerLToolStripMenuItem.Text = "Welcome: "+theUser.fName;
            }
            boldCalendar();
            //setToolStripMenuItemsEnabled(false);
            //showLogin();
        }

        /*Bold calendar for day associa with deadline*/
        public void boldCalendar()
        {
            DateTime[] dateTimes = TaskController.getAllDeadline(theUser).ToArray();
            monthCalendar1.BoldedDates = dateTimes;
        }

        //Returns current instance of this form
        public static mainForm Instance
        {
            get
            {
                return instance;
            }
        }

        public User getUser()
        {
            return CurrentUser.User;
        }

        public void showLogin()
        {
            if (CurrentUser.User == null)
            {
                loginForm = new loginForm();
                //loginForm.MdiParent = this;
                loginForm.StartPosition = FormStartPosition.CenterScreen;
                loginForm.FormClosed += LoginForm_FormClosed;
                loginForm.Show();
                task = new tasksForm(getUser());
            }
            else
                loginForm.Activate();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Dispose();
            loginForm = null;
        }

        //Sets menustrip to enabled/disabled based on user status
        public void setToolStripMenuItemsEnabled(bool value)
        {
            
            managementProfileToolStripMenuItem.Enabled = value;
            changePasswordToolStripMenuItem.Enabled = value;
            registerToolStripMenuItem.Enabled = value;
            addUpdateSubTaskToolStripMenuItem.Enabled = value;
            addUpdateTaskToolStripMenuItem.Enabled = value;
        }

        private void showHomePage()
        {

        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setFormVariables();

            DialogResult result = MessageBox.Show("Are you sure you want to logout, " + CurrentUser.User.fName + "?", "Logging out", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CurrentUser.setCurrentUser(null);
                setToolStripMenuItemsEnabled(false);
                MessageBox.Show("Successfully logged out.");
                closeAllActiveForms();
                this.Hide();
                showLogin();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void managementProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addUpdateAccount == null)
            {
                addUpdateAccount = new AddUpdateAccountForm(getUser());
                //addUpdateAccount.MdiParent = this;
                addUpdateAccount.StartPosition = FormStartPosition.CenterScreen;
                addUpdateAccount.FormClosed += AddUpdateAccount_FormClosed;
                addUpdateAccount.ShowDialog();
            }
            else
            {
                addUpdateAccount.Activate();
            }
        }

        private void AddUpdateAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            addUpdateAccount.Dispose();
            addUpdateAccount = null;
        }

        private void addUpdateTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (task == null)
            {
                task = new tasksForm(theUser);
                //task.MdiParent = this;
                task.StartPosition = FormStartPosition.CenterScreen;
                task.FormClosed += Task_FormClosed;
                task.ShowDialog();
            }
            else
            {
                task.Activate();
            }
        }

        private void Task_FormClosed(object sender, FormClosedEventArgs e)
        {
            task.Dispose();
            task = null;
        }

        private void addUpdateSubTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (childTask == null)
            {
                childTask = new childTasksForm(theUser, null);
                //childTask.MdiParent = this;
                childTask.StartPosition = FormStartPosition.CenterScreen;
                childTask.FormClosed += ChildTask_FormClosed;
                childTask.ShowDialog();
            }
            else
            {
                childTask.Activate();
            }
        }

        private void ChildTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            childTask.Dispose();
            childTask = null;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //if (homepage == null)
            //{
            //    homepage = new homepageForm(getUser());
            //    //homepage.MdiParent = this;
            //    homepage.StartPosition = FormStartPosition.CenterScreen;
            //    homepage.FormClosed += Home_FormClosed;
            //    homepage.Show();
            //}
            //else
            //{
            //    homepage.Activate();
            //}
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            //homepage.Dispose();
            //homepage = null;
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (changePasswordForm == null)
            {
                changePasswordForm = new changePasswordForm(getUser());
                //changePasswordForm.MdiParent = this;
                changePasswordForm.StartPosition = FormStartPosition.CenterScreen;
                changePasswordForm.FormClosed += Password_FormClosed;
                changePasswordForm.ShowDialog();
            }
            else
            {
                changePasswordForm.Activate();
            }
        }

        private void Password_FormClosed(object sender, FormClosedEventArgs e)
        {
            changePasswordForm.Dispose();
            changePasswordForm = null;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            TaskController.updateIncompleteTasksToCurrentDate();
            this.populateScorecard();
        }

        //Helper that sets all form variables to current instance if not null
        private void setFormVariables()
        {
            //addUpdateAccount = AddUpdateAccountForm.Instance;
            //updateChildTask = AddUpdateChildTaskForm.Instance;
            //updateTask = AddUpdateTaskForm.Instance;
            //childTask = childTasksForm.Instance;
            changePasswordForm = changePasswordForm.Instance;
            dateForm = dateForm.Instance;
            //task = tasksForm.Instance;
        }

        //Calls on helper to close all active forms before closing the employee menu form
        public void closeAllActiveForms()
        {
            //homepage.Close();
            //homepage = null;
            ifActiveForm(addUpdateAccount);
            ifActiveForm(updateChildTask);
            ifActiveForm(updateTask);
            //ifActiveForm(childTask);
            ifActiveForm(changePasswordForm);
            ifActiveForm(dateForm);
            //ifActiveForm(task);
        }

        //Helper that sets passed form to null if passed form is not null
        private void ifActiveForm(Form form)
        {
            if (form != null)
            {
                form.Dispose();
                form = null;
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            dateForm dateForm = new dateForm(theUser, this);
            dateForm.ShowDialog();
        }

        // Returns the date selected by the user in a formatted string:
        // Saturday, June 16, 2018
        public String getSelectedDate_Formatted()
        {
            return monthCalendar1.SelectionRange.Start.ToString("D");
        }

        // Returns a the date selected by the user in a short string format:
        // 06/16/2018
        public String getSelectedDate()
        {
            return monthCalendar1.SelectionRange.Start.ToShortDateString();
        }

        private void completedTaskReport(object sender, EventArgs e)
        {
            List<Models.Task> tasks = TaskController.getListTasks(theUser.userID);

            if (tasks.Count == 0)
            {
                MessageBox.Show("It looks like you don't have any tasks right now");
                return;
            }

            if (taskParameter == null)
            {
                taskParameter = new CompletedTaskParameterForm(theUser);
                taskParameter.StartPosition = FormStartPosition.CenterScreen;
                taskParameter.FormClosed += TaskParameter_FormClosed;
                taskParameter.ShowDialog();
            }
            else
            {
                taskParameter.Activate();
            }
        }

        private void TaskParameter_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (taskParameter != null)
            {
                taskParameter.Dispose();
                taskParameter = null;
            }
        }

        //////////SCORECARD CODE//////////

        private void populateScorecard()
        {
            this.populatePieChart();
            this.populateAverageTimeOnTaskLabel();
            this.populatePercentageOnTimeLabel();
            this.populateMeetingLabel();
        }

        /* Populates the pie chart with the current month's data */
        private void populatePieChart()
        {
            chart1.Series.Clear();
            chart1.Legends.Clear();

            chart1.Legends.Add("Tasks");
            chart1.Legends[0].LegendStyle = LegendStyle.Table;
            chart1.Legends[0].Docking = Docking.Right;
            chart1.Legends[0].Alignment = StringAlignment.Center;
            chart1.Legends[0].Title = "Tasks";

            chart1.Series.Add("Tasks");
            chart1.Series["Tasks"].ChartType = SeriesChartType.Pie;

            List<Models.Task> tasks = TaskController.getMonthlyUserTasks(theUser, DateTime.Now.ToShortDateString());

            foreach (Models.Task task in tasks)
            {
                double timeSpent = TaskController.getTimeSpentOnTask(task.taskID);
                double taskPercent = (double)timeSpent / TaskController.getTotalTime(theUser.userID);
                chart1.Series["Tasks"].Points.AddXY(task.title, taskPercent);
            }
            chart1.Series["Tasks"]["PieLabelStyle"] = "Disabled";
        }

        private void populatePercentageOnTimeLabel()
        {
            
            lblPercentCompleteByDeadline.Text = string.Format("{0:P2}", TaskController.getPercent(theUser.userID));
        }

        private void populateAverageTimeOnTaskLabel()
        {
            try
            {
                double averageTime = TaskController.getAverageTime(theUser.userID);
                lblAverageTimeOnTasks.Text = averageTime.ToString("#.##") + "hrs";
                
            }
            catch (Exception)
            {
                MessageBox.Show("You have not logged any time on assignments. Score card information will be limited");
            }
        }

        private void populateMeetingLabel()
        {
            lblMeetingHours.Text = TaskController.getMonthlyMeetingTime(theUser, DateTime.Now.ToShortDateString()).ToString("#.##") + " hrs";
        }

        // Updates the scorecard when tab is selected.
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                this.populateScorecard();
            }
        }
    }
}
