using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouCompleteMe.Controller;
using System.Windows.Forms;
using YouCompleteMe.Models;

namespace YouCompleteMe.Views
{
    public partial class AddUpdateAccountForm : Form
    {
        private static AddUpdateAccountForm instance;
        private User theUser;

        public AddUpdateAccountForm(User user)
        {
            InitializeComponent();
            theUser = user;
            instance = this;
            prepopulateTextBoxes();
        }

        private void prepopulateTextBoxes()
        {
            txtFirstName.Text = theUser.fName;
            txtLastName.Text = theUser.lName;

            phone1.Text = theUser.phone.Substring(1, 3);
            phone2.Text = theUser.phone.Substring(5,3);
            phone3.Text = theUser.phone.Substring(9,4);

            int atChar = theUser.email.IndexOf("@");
            int atPeriod = theUser.email.LastIndexOf(".");

            txtEmail1.Text = theUser.email.Substring(0, atChar);
            txtEmail2.Text = theUser.email.Substring(atChar + 1, atPeriod - atChar - 1);
            txtEmail3.Text = theUser.email.Substring(atPeriod + 1, theUser.email.Length - atPeriod - 1);
            hintText.Text = theUser.hint;
        }

        public static AddUpdateAccountForm Instance
        {
            get
            {
                return instance;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void submitOnClick(object sender, EventArgs e)
        {
            if (validCredentials())
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to submit these changes?", "Submit?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                }
                else
                {
                    return;
                }
            }
        }

        //Helper to evaluate if user has supplied all required information
        private bool validCredentials()
        {
            bool value = true;

            byte[] data = System.Text.Encoding.ASCII.GetBytes(hintText.Text);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

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
            else if (!isValidEmail())
            {
                value = false;
            }
            else if (!isDuplicateEmail(txtEmail1.Text))
            {
                value = false;
            }
            else if (!isValidPhone(phone1.Text, phone2.Text, phone3.Text))
            {
                value = false;
            }
            else if (hintText.Text.Trim() == "")
            {
                MessageBox.Show("Please provide a hint in case you forget your password");
                value = false;
            }
            else if (hash == theUser.password)
            {
                MessageBox.Show("Your hint cannot be your password");
                value = false;
            }
            return value;
        }

        //Helper to see if email already exists in the system
        private bool isDuplicateEmail(string email)
        {
            bool value = true;

            List<User> users = UserController.getUsers();

            for (int current = 0; current<users.Count(); current++)
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

                    if (phoneNum1< 0 || phoneNum2< 0 || phoneNum3< 0)
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
    }
}
