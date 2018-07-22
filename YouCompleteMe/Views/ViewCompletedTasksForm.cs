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
        private List<Models.Task> taskList;
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
            DataSet ds = TaskController.completedReport(theUser.userID, parameter.getStart(), parameter.getEnd());

            //begin for grid data
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoResizeColumns();// = true;
            dataGridView1.DataSource = ds.Tables["tasks"];

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;

            dataGridView1.Columns[3].HeaderText = "Task";
            dataGridView1.Columns[4].HeaderText = "Created Date";
            dataGridView1.Columns[5].HeaderText = "Completed Date";
            dataGridView1.Columns[6].HeaderText = "Due Date";

            dataGridView1.Columns[4].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
            dataGridView1.Columns[5].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
            dataGridView1.Columns[6].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
        }
    }
}
