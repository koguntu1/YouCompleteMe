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
    public partial class changePasswordForm : Form
    {
        private User theUser;
        private static changePasswordForm instance;

        public changePasswordForm(User aUser)
        {
            InitializeComponent();
            this.theUser = aUser;
            instance = this;
        }

        public static changePasswordForm Instance
        {
            get
            {
                return instance;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string current = currentPasswordText.Text;
            string newPass = newPasswordText.Text;
            string retypePass = retypePasswordText.Text;

            try
            {
                if (doesCurrentPasswordMatch(current) && isNewPasswordValid(newPass) && doNewPasswordsMatch(newPass, retypePass))
                {
                    byte[] data = System.Text.Encoding.ASCII.GetBytes(newPass);
                    data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                    String hash = System.Text.Encoding.ASCII.GetString(data);

                    UserController.updatePassword(this.theUser.userName, hash);
                    MessageBox.Show("Password successfully changed");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool doesCurrentPasswordMatch(string password)
        {
            bool match = false;

            string current = UserController.getPassword(this.theUser.userName);

            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

            if (!hash.Equals(current))
            {
                MessageBox.Show("Current password is incorrect. Please try again");
            }
            else
            {
                match = true;
            }

            return match;
        }

        //Helper that returns true if passed string matches all patterns. If false, the appropriate 
        //text box will be displayed
        private bool isNewPasswordValid(string password)
        {
            bool isValid = false;

            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

            Regex hasNumber = new Regex(@"[0-9]+");
            Regex hasUpperChar = new Regex(@"[A-Z]+");
            Regex hasLowerChar = new Regex(@"[a-z]+");
            Regex hasSymbols = new Regex(@"[!@#$%^*()]");

            if (hash.Equals(UserController.getPassword(this.theUser.userName)))
            {
                MessageBox.Show("Please enter a different password from your current password");
            }
            else if (password.Length < 8)
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

        //Returns true if retyped new password matches new password
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
