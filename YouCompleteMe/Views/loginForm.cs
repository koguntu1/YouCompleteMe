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
    public partial class loginForm : Form
    {
        private int counter;

        public loginForm()
        {
            InitializeComponent();
            counter = 0;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            registerForm registerForm = new registerForm();
            
            this.Hide();
            var registerF = new registerForm();
            registerF.Closed += (s, args) => this.Close();
            registerF.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(textBox2.Text);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

            CurrentUser.setCurrentUser(UserController.getAUser(textBox1.Text, hash));

            if (textBox1.Text.Trim().Equals("") || textBox2.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please provide your username and password, or register below");
            }
            else if (CurrentUser.User == null)
            {
                counter++;
                MessageBox.Show("We couldn't find you. Please try again");
            }
            else
            {
                MessageBox.Show("Welcome " + CurrentUser.User.fName);
                this.Hide();
                var mainForm = new mainForm(CurrentUser.User);
                mainForm.Closed += (s, args) => this.Close();
                mainForm.Show();
            }

            if (counter == 3)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to reset your password?", "Did You Forget Your Password?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Hide();
                    var resetPassword = new resetPassword();
                    resetPassword.Closed += (s, args) => this.Close();
                    resetPassword.Show();
                    counter = 0;
                }
                else if (dialogResult == DialogResult.No)
                {
                    counter = 0;
                    return;
                }
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var resetPassword = new resetPassword();
            resetPassword.Closed += (s, args) => this.Close();
            resetPassword.Show();
        }
    }
}
