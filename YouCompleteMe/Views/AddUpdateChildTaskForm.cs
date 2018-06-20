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
    public partial class AddUpdateChildTaskForm : Form
    {
        private static AddUpdateChildTaskForm instance;

        public AddUpdateChildTaskForm()
        {
            InitializeComponent();
            instance = this;
        }

        public static AddUpdateChildTaskForm Instance
        {
            get
            {
                return instance;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
