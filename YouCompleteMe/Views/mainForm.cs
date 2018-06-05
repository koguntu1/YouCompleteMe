using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouCompleteMe.Views
{
    public partial class mainForm : Form
    {
        homepageForm homepage = new homepageForm();
        AddUpdateAccountForm addUpdateAccount = new AddUpdateAccountForm();
        tasksForm task = new tasksForm();
        childTasksForm childTask = new childTasksForm();
        changePasswordForm changePasswordForm = new changePasswordForm();

        public mainForm()
        {
            InitializeComponent();
            showHomePage();
        }

        private void showHomePage()
        {
            if (homepage.Enabled)
            {
                if (homepage.IsDisposed)
                {
                    homepage = new homepageForm();
                    homepage.MdiParent = this;
                    homepage.StartPosition = FormStartPosition.CenterScreen;
                    homepage.WindowState = FormWindowState.Maximized;
                    homepage.Show();
                }
                else
                {
                    homepage.MdiParent = this;
                    homepage.StartPosition = FormStartPosition.CenterScreen;
                    homepage.WindowState = FormWindowState.Maximized;
                    homepage.Show();
                }
            }
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new loginForm();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    task = new tasksForm();
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
                    changePasswordForm = new changePasswordForm();
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
    }
}
