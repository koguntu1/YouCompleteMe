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
        private User user;

        private static homepageForm instance;

        public homepageForm(User _user)
        {
            InitializeComponent();
            user = _user;
            instance = this;
        }

        public static homepageForm Instance
        {
            get
            {
                return instance;
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            dateForm dateForm = new dateForm(user, this);
            dateForm.Show();
        }

        // Returns the date selected by the user in a formatted string:
        // Saturday, June 16, 2018
        public String getSelectedDate_Formatted()
        {
            return monthCalendar1.SelectionRange.Start.ToString("D");
        }

        // Returns a the date selected by the user in a short string format:
        // 06/16/2018
        public String getSelectedDate()
        {
            return monthCalendar1.SelectionRange.Start.ToShortDateString();
        }
    }
}
