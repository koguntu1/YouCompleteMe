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
        private User theUser;
        private static mainForm instance;
        private static loginForm loginForm;
        private static homepageForm homepage;

        AddUpdateAccountForm addUpdateAccount = new AddUpdateAccountForm();
        tasksForm task;
        childTasksForm childTask = new childTasksForm();
        private changePasswordForm changePasswordForm;

        public mainForm()
        {
            instance = this;
            InitializeComponent();
            task = new tasksForm(theUser);
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

        private void showLogin()
        {
            if (CurrentUser.User == null)
            {
                loginForm = new loginForm();
                loginForm.MdiParent = this;
                loginForm.StartPosition = FormStartPosition.CenterScreen;
                loginForm.FormClosed += LoginForm_FormClosed;
                loginForm.Show();
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
            if (addUpdateAccount.Enabled)
            {
                if (addUpdateAccount.IsDisposed)
                {
                    addUpdateAccount = new AddUpdateAccountForm();
                    addUpdateAccount.MdiParent = this;
                    addUpdateAccount.StartPosition = FormStartPosition.CenterScreen;
                    addUpdateAccount.Show();
                }
                else
                {
                    addUpdateAccount.MdiParent = this;
                    addUpdateAccount.StartPosition = FormStartPosition.CenterScreen;
                    addUpdateAccount.Show();
                }
            }
        }

        private void addUpdateTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (task.Enabled)
            {
                if (task.IsDisposed)
                {
                    task = new tasksForm(theUser);
                    task.MdiParent = this;
                    task.StartPosition = FormStartPosition.CenterScreen;
                    task.Show();
                }
                else
                {
                    task.MdiParent = this;
                    task.StartPosition = FormStartPosition.CenterScreen;
                    task.Show();
                }
            }
        }

        private void addUpdateSubTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (childTask.Enabled)
            {
                if (childTask.IsDisposed)
                {
                    childTask = new childTasksForm();
                    childTask.MdiParent = this;
                    childTask.StartPosition = FormStartPosition.CenterScreen;
                    childTask.Show();
                }
                else
                {
                    childTask.MdiParent = this;
                    childTask.StartPosition = FormStartPosition.CenterScreen;
                    childTask.Show();
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showHomePage();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (changePasswordForm.Enabled)
            {
                if (changePasswordForm.IsDisposed)
                {
                    changePasswordForm = new changePasswordForm(this.theUser);
                    changePasswordForm.MdiParent = this;
                    changePasswordForm.StartPosition = FormStartPosition.CenterScreen;
                    changePasswordForm.WindowState = FormWindowState.Maximized;
                    changePasswordForm.Show();
                }
                else
                {
                    changePasswordForm.MdiParent = this;
                    changePasswordForm.StartPosition = FormStartPosition.CenterScreen;
                    changePasswordForm.WindowState = FormWindowState.Maximized;
                    changePasswordForm.Show();
                }
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            TaskController.updateIncompleteTasksToCurrentDate();
        }

        //Helper that sets all form variables to current instance if not null
        private void setFormVariables()
        {
            homepage = homepageForm.Instance;
        }

        //Calls on helper to close all active forms before closing the employee menu form
        private void closeAllActiveForms()
        {
            homepage.Close();
            homepage = null;
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
