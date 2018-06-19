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
    public partial class resetPassword : Form
    {
        public resetPassword()
        {
            InitializeComponent();
        }

        private void cancelOnClick(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new loginForm();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void submitOnClick(object sender, EventArgs e)
        {
            if (validated())
            {
                MessageBox.Show("Your password was reset");
                this.Hide();
                var loginForm = new loginForm();
                loginForm.Closed += (s, args) => this.Close();
                loginForm.Show();
            }
        }

        //Verifies that all fields are correctly filled out
        private bool validated()
        {
            bool value = true;

            if (userNameText.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your user name");
                value = false;
            }
            else if (hintText.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your password hint");
                value = false;
            }
            else if (!isValidCredentials())
            {
                value = false;
            }
                
            return value;
        }

        private bool isValidCredentials()
        {
            bool value = true;

            CurrentUser.setCurrentUser(UserController.verifyAUser(userNameText.Text, hintText.Text));

            if (CurrentUser.User == null)
            {
                MessageBox.Show("Incorrect user name or hint");
                value = false;
            }
            return value;
        }
    }
}
