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
            dataGridView1.ReadOnly = true;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            //dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;

            dataGridView1.Columns[3].HeaderText = "Task";
            dataGridView1.Columns[4].HeaderText = "Created Date";
            dataGridView1.Columns[5].HeaderText = "Completed Date";
            dataGridView1.Columns[6].HeaderText = "Due Date";
            dataGridView1.Columns[7].HeaderText = "On Time?";
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "task_priority")
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[5].Value != DBNull.Value && dataGridView1.Rows[e.RowIndex].Cells[6].Value != DBNull.Value)
                {
                    if (Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[5].Value) > Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[6].Value))
                    {
                        e.Value = "No";
                    }
                    else
                    {
                        e.Value = "Yes";
                    }
                }
                else
                {
                    e.Value = "";
                }
            }
        }
    }
}
