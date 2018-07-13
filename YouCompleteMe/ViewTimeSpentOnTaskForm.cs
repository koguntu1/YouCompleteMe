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
using YouCompleteMe.Views;

namespace YouCompleteMe
{
    public partial class ViewTimeSpentOnTaskForm : Form
    {
        private static CompletedTaskParameterForm parameter;
        private User theUser;

        public ViewTimeSpentOnTaskForm(CompletedTaskParameterForm aParameter, User aUser)
        {
            InitializeComponent();
            parameter = aParameter;
            theUser = aUser;
        }

        private void ViewTimeSpentOnTaskForm_Load(object sender, EventArgs e)
        {
            this.tasksTableAdapter.Fill(this.TimeSpentDataSet.tasks, theUser.userID, parameter.getStart(), parameter.getEnd());
            this.reportViewer1.RefreshReport();
        }
    }
}
