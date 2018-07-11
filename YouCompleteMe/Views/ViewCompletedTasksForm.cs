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

        public ViewCompletedTasksForm(CompletedTaskParameterForm aParameter, User aUser)
        {
            instance = this;
            parameter = aParameter;
            theUser = aUser;

            InitializeComponent();
        }

        public ViewCompletedTasksForm Instance
        {
            get
            {
                return instance;
            }
        }

        private void ViewCompletedTasksForm_Load(object sender, EventArgs e)
        {
            this.tasks1TableAdapter.Fill(this.completedTaskDataSet.tasks1, theUser.userID, parameter.getStart(), parameter.getEnd());
            this.reportViewer1.RefreshReport();
        }
    }
}
