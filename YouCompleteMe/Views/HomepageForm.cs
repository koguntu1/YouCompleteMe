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
    public partial class homepageForm : Form
    {
        User user;
        public homepageForm(User _user)
        {
            InitializeComponent();
            user = _user;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            dateForm dateForm = new dateForm(user);
            dateForm.Show();
        }
    }
}
