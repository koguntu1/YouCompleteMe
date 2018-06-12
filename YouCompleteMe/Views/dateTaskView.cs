using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouCompleteMe.Views
{
    public partial class dateTaskView : Form
    {
        private homepageForm calendarParent;
        public dateTaskView(homepageForm calendarParent)
        {
            this.calendarParent = calendarParent;
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTaskView_Load(object sender, EventArgs e)
        {
            this.label1.Text = calendarParent.getSelectedDate();
        }
    }
}
