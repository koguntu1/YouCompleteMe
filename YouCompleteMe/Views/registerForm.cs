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
    public partial class registerForm : Form
    {
        private string phoneNumber;

        public registerForm()
        {
            InitializeComponent();
        }

        //Defines action of exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Defines action of the submit button
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (validCredentials())
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(txtPassword.Text);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                String hash = System.Text.Encoding.ASCII.GetString(data);

                this.phoneNumber = label17.Text + phone1.Text + label18.Text + phone2.Text + label10.Text + phone3.Text;
                string email = txtEmail1.Text + label16.Text + txtEmail2.Text + label19.Text + txtEmail3.Text;

                UserController.createUser(txtUser.Text, txtFirstName.Text, txtLastName.Text, email, this.phoneNumber, hash, hintText.Text);

                MessageBox.Show("Thank you for registering. Returning to login screen");
                this.Hide();
                var loginForm = new loginForm();
                loginForm.Closed += (s, args) => this.Close();
                loginForm.Show();
            }
        }

        //Helper to evaluate if user has supplied all required information
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
            else if (!isDuplicateName(txtUser.Text))
            {
                value = false;
            }
            else if (!isValidEmail())
            {
                value = false;
            }
            else if (!isDuplicateEmail(txtEmail1.Text + label16.Text + txtEmail2.Text + label19.Text + txtEmail3.Text))
            {
                value = false;
            }
            else if (!isValidPhone(phone1.Text, phone2.Text, phone3.Text))
            {
                value = false;
            }
            else if (!isNewPasswordValid(txtPassword.Text))
            {
                value = false;
            }
            else if (!doNewPasswordsMatch(txtPassword.Text, txtConfirmPassword.Text))
            {
                value = false;
            }
            else if (hintText.Text.Trim() == "")
            {
                MessageBox.Show("Please provide a hint in case you forget your password");
                value = false;
            }
            else if (hintText.Text.Equals(txtPassword.Text))
            {
                MessageBox.Show("Your hint cannot be your password");
                value = false;
            }
            return value;
        }

        //Helper to see if a user name already exists in the system
        private bool isDuplicateName(string userName)
        {
            bool value = true;

            List<User> users = UserController.getUsers();

            for (int current = 0; current < users.Count(); current++)
            {
                User user = users[current];
                if (user.userName.Equals(userName)) {
                    MessageBox.Show("Username already exists");
                    value = false;
                }
            }

            return value;
        }

        //Helper to see if email already exists in the system
        private bool isDuplicateEmail(string email)
        {
            bool value = true;

            List<User> users = UserController.getUsers();

            for (int current = 0; current < users.Count(); current++)
            {
                User user = users[current];
                if (user.email.Equals(email))
                {
                    MessageBox.Show("Email address already exists");
                    value = false;
                }
            }

            return value;
        }

        //Helper to evaluate if supplied phone number is in a valid format
        private bool isValidPhone(string first, string second, string third)
        {
            bool value = true;

            if (first.Length != 3)
            {
                MessageBox.Show("Area code must be three digits");
                value = false;
            }
            else if (second.Length != 3)
            {
                MessageBox.Show("Second section must be three digits");
                value = false;
            }
            else if (third.Length != 4)
            {
                MessageBox.Show("Last section must be four digits");
                value = false;
            }
            else
            {
                try
                {
                    int phoneNum1 = (int)Int64.Parse(first);
                    int phoneNum2 = (int)Int64.Parse(second);
                    int phoneNum3 = (int)Int64.Parse(third);

                    if (phoneNum1 < 0 || phoneNum2 < 0 || phoneNum3 < 0)
                    {
                        MessageBox.Show("Phone cannot contain non-numbers");
                        value = false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Phone cannot contain non-numbers");
                    value = false;
                }
            }
            return value;
        }

        //Helper to evaluate if supplied email is in a valid format
        private Boolean isValidEmail()
        {
            bool value = true;

            if (txtEmail1.Text == "" || txtEmail2.Text == "" || txtEmail3.Text == "") 
            {
                MessageBox.Show("Please provide a valid email address");
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
