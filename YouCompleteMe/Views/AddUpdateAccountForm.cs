using System;
using System.Collections;
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
    }
}
