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
    public partial class ViewAverageTimePerTask : Form
    {
        private static CompletedTaskParameterForm parameter;
        private User theUser;
        public ViewAverageTimePerTask(CompletedTaskParameterForm aParameter, User aUser)
        {
            parameter = aParameter;
            theUser = aUser;
            InitializeComponent();
        }

        private void ViewAverageTimePerTask_Load(object sender, EventArgs e)
        {
            this.tasksTableAdapter.Fill(this.averageTimeDataSet.tasks, theUser.userID, parameter.getStart(), parameter.getEnd());
            this.reportViewer1.RefreshReport();
        }
    }
}
