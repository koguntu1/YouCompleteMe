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
    public partial class dateTaskView : Form
    {
        private homepageForm calendarParent;
        private TasksController taskController;

        public dateTaskView(homepageForm calendarParent)
        {
            this.calendarParent = calendarParent;
            this.taskController = new TasksController();
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTaskView_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'project6920DataSet.tasks' table. You can move, or remove it, as needed.
            this.tasksTableAdapter.Fill(this.project6920DataSet.tasks);
            this.dateLabel.Text = calendarParent.getSelectedDate();
            //this.populateTaskList();
        }

        private void populateTaskList()
        {
            
        }

        private void tasksBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tasksBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.project6920DataSet);

        }
    }
}
