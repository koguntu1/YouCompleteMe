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

namespace YouCompleteMe.Views
{
    public partial class registerForm : Form
    {
        private string phoneNumber;
        public registerForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new loginForm();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string pass = txtPassword.Text;
            string retypePass = txtConfirmPassword.Text;

            if (validCredentials() && isNewPasswordValid(pass) && doNewPasswordsMatch(pass, retypePass))
            {

                this.phoneNumber = phone1.Text + phone2.Text + phone3.Text;

                this.Hide();
                var loginForm = new loginForm();
                loginForm.Closed += (s, args) => this.Close();
                loginForm.Show();
            }
        }

        private bool validCredentials()
        {
            bool value = true;

            if (txtFirstName.Text == "")
            {
                MessageBox.Show("Please enter your first name");
                value = false;
            }
            else if (txtLastName.Text == "")
            {
                MessageBox.Show("Please enter your last name");
                value = false;
            }
            else if (txtUser.Text == "")
            {
                MessageBox.Show("Please enter a user name");
                value = false;
            }

            if (isValidPhone(phone1.Text, phone2.Text, phone3.Text))
            {
                value = true;
            }
            else if (isValidEmail(txtEmail.Text))
            {
                value = true;
            }
            return value;
        }

        private Boolean isValidPhone(string first, string second, string third)
        {
            try
            {
                int phoneNum1 = (int)Int64.Parse(first);

                if (phoneNum1 < 0 || first.Length != 3)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            try
            {
                int phoneNum2 = (int)Int64.Parse(second);

                if (phoneNum2 < 0 || second.Length != 3)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            try
            {
                int phoneNum3 = (int)Int64.Parse(third);

                if (phoneNum3 < 0 || third.Length != 4)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private Boolean isValidEmail(string email)
        {
            Regex hasSymbol = new Regex(@"[@]");

            if (email == "") 
            {
                return false;
            }
            else if (!hasSymbol.IsMatch(email))
            {
                return false;
            }

            return true;
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
