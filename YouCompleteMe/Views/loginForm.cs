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
    public partial class loginForm : Form
    {
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
            this.Hide();
            var mainForm = new mainForm();
            mainForm.Closed += (s, args) => this.Close();
            mainForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
