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
    public partial class ViewCompletedTasksForm : Form
    {
        private static CompletedTaskParameterForm parameter;
        private static ViewCompletedTasksForm instance;
        private User theUser;

        public ViewCompletedTasksForm(User aUser)
        {
            instance = this;
            theUser = aUser;

            InitializeComponent();
            startDate.Value = TaskController.getMinDate(theUser.userID);
            endDate.Value = TaskController.getMinDate(theUser.userID);
        }

        public ViewCompletedTasksForm Instance
        {
            get
            {
                return instance;
            }
        }

        private void submitOnClick(object sender, EventArgs e)
        {
            this.tasks1TableAdapter1.Fill(this.completedTaskDataSet.tasks1, theUser.userID, startDate.Value, endDate.Value);
            this.reportViewer1.RefreshReport();
        }

        private void closeOnClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
