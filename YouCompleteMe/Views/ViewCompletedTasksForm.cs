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
    }
}
