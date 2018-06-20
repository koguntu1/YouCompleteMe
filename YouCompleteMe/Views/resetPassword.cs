using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            this.Close();
        }

        private void submitOnClick(object sender, EventArgs e)
        {
            if (validated())
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(passwordText.Text);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                String hash = System.Text.Encoding.ASCII.GetString(data);

                UserController.updatePassword(CurrentUser.User.userName, hash);
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
            else if (!isNewPasswordValid(passwordText.Text))
            {
                value = false;
            }
            else if (!doNewPasswordsMatch(passwordText.Text, confirmText.Text))
            {
                value = false;
            }
            return value;
        }

        //Helper that returns true if passed string matches all patterns. If false, the appropriate 
        //text box will be displayed
        private bool isNewPasswordValid(string password)
        {
            bool isValid = false;

            Regex hasNumber = new Regex(@"[0-9]+");
            Regex hasUpperChar = new Regex(@"[A-Z]+");
            Regex hasLowerChar = new Regex(@"[a-z]+");
            Regex hasSymbols = new Regex(@"[!@#$%^*()]");

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters in length");
            }
            else if (!hasLowerChar.IsMatch(password))
            {
                MessageBox.Show("Password does not contain a lowercase letter");
            }
            else if (!hasUpperChar.IsMatch(password))
            {
                MessageBox.Show("Password does not contain a uppercase letter");
            }
            else if (!hasNumber.IsMatch(password))
            {
                MessageBox.Show("Password does not contain a number");
            }
            else if (!hasSymbols.IsMatch(password))
            {
                MessageBox.Show("Password does not contain a symbol");
            }
            else
            {
                isValid = true;
            }
            return isValid;
        }

        //Helper that returns true if retyped new password matches new password
        private bool doNewPasswordsMatch(string password1, string password2)
        {
            bool isMatch = false;

            if (!password1.Equals(password2))
            {
                MessageBox.Show("New password and re-typed password do not match");
            }
            else
            {
                isMatch = true;
            }
            return isMatch;
        }
       
    }
}
