namespace YouCompleteMe.Views
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUpdateTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementSubTaskToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addUpdateSubTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uerLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.managementTasksToolStripMenuItem,
            this.managementSubTaskToolStripMenuItem1,
            this.reportsToolStripMenuItem,
            this.uerLToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 10, 2);
            this.menuStrip1.Size = new System.Drawing.Size(691, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.managementProfileToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.registerToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(138, 20);
            this.homeToolStripMenuItem.Text = "Management Account";
            // 
            // managementProfileToolStripMenuItem
            // 
            this.managementProfileToolStripMenuItem.Name = "managementProfileToolStripMenuItem";
            this.managementProfileToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.managementProfileToolStripMenuItem.Text = "Manage Profile";
            this.managementProfileToolStripMenuItem.Click += new System.EventHandler(this.managementProfileToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.registerToolStripMenuItem.Text = "Logout";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.registerToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // managementTasksToolStripMenuItem
            // 
            this.managementTasksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUpdateTaskToolStripMenuItem});
            this.managementTasksToolStripMenuItem.Name = "managementTasksToolStripMenuItem";
            this.managementTasksToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.managementTasksToolStripMenuItem.Text = "Task Management";
            // 
            // addUpdateTaskToolStripMenuItem
            // 
            this.addUpdateTaskToolStripMenuItem.Name = "addUpdateTaskToolStripMenuItem";
            this.addUpdateTaskToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.addUpdateTaskToolStripMenuItem.Text = "Add/UpdateTask";
            this.addUpdateTaskToolStripMenuItem.Click += new System.EventHandler(this.addUpdateTaskToolStripMenuItem_Click);
            // 
            // managementSubTaskToolStripMenuItem1
            // 
            this.managementSubTaskToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUpdateSubTaskToolStripMenuItem});
            this.managementSubTaskToolStripMenuItem1.Name = "managementSubTaskToolStripMenuItem1";
            this.managementSubTaskToolStripMenuItem1.Size = new System.Drawing.Size(134, 20);
            this.managementSubTaskToolStripMenuItem1.Text = "Subtask Management";
            this.managementSubTaskToolStripMenuItem1.Visible = false;
            // 
            // addUpdateSubTaskToolStripMenuItem
            // 
            this.addUpdateSubTaskToolStripMenuItem.Name = "addUpdateSubTaskToolStripMenuItem";
            this.addUpdateSubTaskToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.addUpdateSubTaskToolStripMenuItem.Text = "Add/Update Sub Task";
            this.addUpdateSubTaskToolStripMenuItem.Click += new System.EventHandler(this.addUpdateSubTaskToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // uerLToolStripMenuItem
            // 
            this.uerLToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.uerLToolStripMenuItem.Name = "uerLToolStripMenuItem";
            this.uerLToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.uerLToolStripMenuItem.Text = "User_Login";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(3, 4);
            this.monthCalendar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthCalendar1.Location = new System.Drawing.Point(0, 24);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 631);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "You Complete Me Application";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managementProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managementTasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUpdateTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uerLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managementSubTaskToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addUpdateSubTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}