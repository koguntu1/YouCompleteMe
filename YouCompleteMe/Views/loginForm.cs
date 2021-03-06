﻿using System;
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
        private static registerForm registerForm;
        private static resetPassword resetForm;

        public loginForm()
        {
            InitializeComponent();
            counter = 0;
            viewPWll.Text = "\uD83D\uDC41";
            viewPWll.LinkBehavior = LinkBehavior.NeverUnderline;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (registerForm == null)
            {
                if (CurrentUser.User == null)
                {
                    registerForm = new registerForm();
                    //registerForm.MdiParent = mainForm.Instance;
                    registerForm.StartPosition = FormStartPosition.CenterScreen;
                    registerForm.FormClosed += RegisterForm_FormClosed;
                    this.Hide();
                    registerForm.Show();
                }
                else
                    registerForm.Activate();
            }
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            registerForm.Dispose();
            registerForm = null;
            this.Show();
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
                //this.Close();

                //homeForm = new homepageForm(CurrentUser.User);
                //homeForm.MdiParent = mainForm.Instance;
                //homeForm.WindowState = FormWindowState.Maximized;
                //homeForm.FormClosed += new FormClosedEventHandler(HomeForm_FormClosed);
                //homeForm.StartPosition = FormStartPosition.CenterScreen;
                //mainForm.Instance.setToolStripMenuItemsEnabled(true);
                //homeForm.Show();

                /* Begin fix*/
                this.Hide();
                var form2 = new mainForm(CurrentUser.User);
                form2.Closed += (s, args) => this.Close();
                form2.Show();

            }

            if (counter == 3)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to reset your password?", "Forgot Password?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    counter = 0;
                    if (resetForm == null)
                    {
                        this.Hide();
                        resetForm = new resetPassword();
                        //resetForm.MdiParent = mainForm.Instance;
                        resetForm.FormClosed += new FormClosedEventHandler(ResetForm_FormClosed);
                        resetForm.StartPosition = FormStartPosition.CenterScreen;
                        resetForm.Show();
                    }
                    else
                    {
                        resetForm.Activate();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    counter = 0;
                    return;
                }
            }
            
        }

        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //homeForm.Dispose();
            //homeForm = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (resetForm == null)
            {
                this.Hide();
                resetForm = new resetPassword();
                //resetForm.MdiParent = mainForm.Instance;
                resetForm.FormClosed += new FormClosedEventHandler(ResetForm_FormClosed);
                resetForm.StartPosition = FormStartPosition.CenterScreen;
                resetForm.Show();
            }
            else
            {
                resetForm.Activate();
            } 
        }

        private void ResetForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            resetForm.Dispose();
            resetForm.Close();
            resetForm = null;
            this.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox2.UseSystemPasswordChar = !textBox2.UseSystemPasswordChar;
        }
    }
}
