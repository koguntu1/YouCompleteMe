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
    public partial class mainForm : Form
    {
        private static mainForm instance;
        private static loginForm loginForm;
        private static homepageForm homepage;
        private static AddUpdateAccountForm addUpdateAccount;
        private static AddUpdateChildTaskForm updateChildTask;
        private static AddUpdateTaskForm updateTask;
        private static childTasksForm childTask;
        private changePasswordForm changePasswordForm;
        private static dateForm dateForm;
        private static tasksForm task;

        public mainForm()
        {
            instance = this;
            InitializeComponent();
            setToolStripMenuItemsEnabled(false);
            showLogin();
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

        private void showLogin()
        {
            if (CurrentUser.User == null)
            {
                loginForm = new loginForm();
                loginForm.MdiParent = this;
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
            toolStripMenuItem1.Enabled = value;
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
                addUpdateAccount.MdiParent = this;
                addUpdateAccount.StartPosition = FormStartPosition.CenterScreen;
                addUpdateAccount.FormClosed += AddUpdateAccount_FormClosed;
                addUpdateAccount.Show();
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
                task = new tasksForm(getUser());
                task.MdiParent = this;
                task.StartPosition = FormStartPosition.CenterScreen;
                task.FormClosed += Task_FormClosed;
                task.Show();
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
                childTask = new childTasksForm();
                childTask.MdiParent = this;
                childTask.StartPosition = FormStartPosition.CenterScreen;
                childTask.FormClosed += ChildTask_FormClosed;
                childTask.Show();
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
            if (homepageForm.Instance == null && homepage == null)
            {
                homepage = new homepageForm(getUser());
                homepage.MdiParent = this;
                homepage.StartPosition = FormStartPosition.CenterScreen;
                homepage.FormClosed += Home_FormClosed;
                homepage.Show();
            }
            else
            {
                homepage.Activate();
            }
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            homepage.Dispose();
            homepage = null;
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (changePasswordForm == null)
            {
                changePasswordForm = new changePasswordForm(getUser());
                changePasswordForm.MdiParent = this;
                changePasswordForm.StartPosition = FormStartPosition.CenterScreen;
                changePasswordForm.FormClosed += Password_FormClosed;
                changePasswordForm.Show();
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
        }

        //Helper that sets all form variables to current instance if not null
        private void setFormVariables()
        {
            homepage = homepageForm.Instance;
            addUpdateAccount = AddUpdateAccountForm.Instance;
            updateChildTask = AddUpdateChildTaskForm.Instance;
            updateTask = AddUpdateTaskForm.Instance;
            childTask = childTasksForm.Instance;
            changePasswordForm = changePasswordForm.Instance;
            dateForm = dateForm.Instance;
            task = tasksForm.Instance;
        }

        //Calls on helper to close all active forms before closing the employee menu form
        private void closeAllActiveForms()
        {
            homepage.Close();
            homepage = null;
            ifActiveForm(addUpdateAccount);
            ifActiveForm(updateChildTask);
            ifActiveForm(updateTask);
            ifActiveForm(childTask);
            ifActiveForm(changePasswordForm);
            ifActiveForm(dateForm);
            ifActiveForm(task);
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
    }
}
