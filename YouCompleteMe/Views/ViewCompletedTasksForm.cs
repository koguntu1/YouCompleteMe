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
    public partial class ViewCompletedTasksForm : Form
    {
        private static CompletedTaskParameterForm parameter;
        private static ViewCompletedTasksForm instance;

        public ViewCompletedTasksForm(CompletedTaskParameterForm parameters)
        {
            instance = this;
            parameter = parameters;
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
            this.tasks1TableAdapter1.Fill(this.completedTaskDataSet.tasks1, parameter.getUser().userID, parameter.getStart(), parameter.getEnd());
            this.reportViewer1.RefreshReport();
        }
    }
}
