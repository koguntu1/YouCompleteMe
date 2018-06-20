using System;
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
    public partial class AddUpdateAccountForm : Form
    {
        private static AddUpdateAccountForm instance;
        private User theUser;

        public AddUpdateAccountForm(User user)
        {
            InitializeComponent();
            theUser = user;
            instance = this;
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
