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
            DataSet ds = TaskController.averageTimeReport(theUser.userID, parameter.getStart(), parameter.getEnd());

            //begin for grid data
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoResizeColumns();// = true;
            dataGridView1.DataSource = ds.Tables["tasks"];

            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;


            dataGridView1.Columns[0].HeaderText = "Task";
            dataGridView1.Columns[1].HeaderText = "Number of Sessions";
            dataGridView1.Columns[2].HeaderText = "Average Time";
            dataGridView1.Columns[3].HeaderText = "Total Time";
        }
    }
}
