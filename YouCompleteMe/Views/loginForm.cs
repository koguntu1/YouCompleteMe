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

        private User theUser;

        public loginForm()
        {
            InitializeComponent();
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
            CurrentUser.setCurrentUser(UserController.getAUser(textBox1.Text, textBox2.Text));

            if (textBox1.Text.Trim().Equals("") || textBox2.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please provide your username and password, or register below");
            }
            else if (CurrentUser.User == null)
            {
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
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
