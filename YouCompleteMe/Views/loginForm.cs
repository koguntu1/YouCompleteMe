﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouCompleteMe.Models;

namespace YouCompleteMe.Views
{
    public partial class loginForm : Form
    {

        private User theUser;

        public loginForm()
        {
            theUser = null;
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
            if (theUser == null)
            {
                MessageBox.Show("Please enter your username and password, or register with us");
            }
            this.Hide();
            var mainForm = new mainForm(new User());
            mainForm.Closed += (s, args) => this.Close();
            mainForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
