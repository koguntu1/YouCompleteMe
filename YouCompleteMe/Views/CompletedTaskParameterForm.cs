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
    public partial class CompletedTaskParameterForm : Form
    {
        private static CompletedTaskParameterForm instance;
        private User theUser;

        public CompletedTaskParameterForm(User aUser)
        {
            instance = this;
            theUser = aUser;
            InitializeComponent();
            reset();
        }

        //Return the current instance of this form
        public CompletedTaskParameterForm Instance
        {
            get
            {
                return this;
            }
        }

        private void submitOnClick(object sender, EventArgs e)
        {

        }

        private void cancelOnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        //Helper to reset combo box and dates to default values
        private void reset()
        {
            startDate.Value = TaskController.getMinDate(theUser.userID);
            endDate.Value = TaskController.getMinDate(theUser.userID);
        }
    }
}
