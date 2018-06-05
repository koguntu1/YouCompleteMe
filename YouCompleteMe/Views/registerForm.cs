using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouCompleteMe.Views
{
    public partial class registerForm : Form
    {
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
            this.Hide();
            var loginForm = new loginForm();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }
    }
}
