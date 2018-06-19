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
    public partial class changePasswordForm : Form
    {
        private User theUser;

        public changePasswordForm(User aUser)
        {
            InitializeComponent();
            this.theUser = aUser;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string current = currentPasswordText.Text;
            string newPass = newPasswordText.Text;
            string retypePass = retypePasswordText.Text;

            try
            {
                if (doesCurrentPasswordMatch(current))
                {
                    MessageBox.Show("Woohoo");
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
    }
}
