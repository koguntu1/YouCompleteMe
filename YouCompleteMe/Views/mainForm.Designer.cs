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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUpdateTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completedTaskReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementSubTaskToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addUpdateSubTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uerLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.calendarTab = new System.Windows.Forms.TabPage();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.scorecardTab = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblPercentCompleteByDeadline = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAverageTimeOnTasks = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblMeetingHours = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.calendarTab.SuspendLayout();
            this.scorecardTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.managementTasksToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.managementSubTaskToolStripMenuItem1,
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
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.completedTaskReportToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // completedTaskReportToolStripMenuItem
            // 
            this.completedTaskReportToolStripMenuItem.Name = "completedTaskReportToolStripMenuItem";
            this.completedTaskReportToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.completedTaskReportToolStripMenuItem.Text = "View Reports";
            this.completedTaskReportToolStripMenuItem.Click += new System.EventHandler(this.completedTaskReport);
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
            // uerLToolStripMenuItem
            // 
            this.uerLToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.uerLToolStripMenuItem.Name = "uerLToolStripMenuItem";
            this.uerLToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.uerLToolStripMenuItem.Text = "User_Login";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.calendarTab);
            this.tabControl1.Controls.Add(this.scorecardTab);
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(691, 482);
            this.tabControl1.TabIndex = 3;
            // 
            // calendarTab
            // 
            this.calendarTab.Controls.Add(this.monthCalendar1);
            this.calendarTab.Location = new System.Drawing.Point(4, 22);
            this.calendarTab.Name = "calendarTab";
            this.calendarTab.Padding = new System.Windows.Forms.Padding(3);
            this.calendarTab.Size = new System.Drawing.Size(683, 456);
            this.calendarTab.TabIndex = 0;
            this.calendarTab.Text = "Calendar";
            this.calendarTab.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(3, 3);
            this.monthCalendar1.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // scorecardTab
            // 
            this.scorecardTab.Controls.Add(this.splitContainer1);
            this.scorecardTab.Location = new System.Drawing.Point(4, 22);
            this.scorecardTab.Name = "scorecardTab";
            this.scorecardTab.Padding = new System.Windows.Forms.Padding(3);
            this.scorecardTab.Size = new System.Drawing.Size(683, 456);
            this.scorecardTab.TabIndex = 1;
            this.scorecardTab.Text = "Scorecard";
            this.scorecardTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            this.splitContainer1.Panel1.Controls.Add(this.chart1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblPercentCompleteByDeadline);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.lblAverageTimeOnTasks);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.lblMeetingHours);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Size = new System.Drawing.Size(683, 456);
            this.splitContainer1.SplitterDistance = 403;
            this.splitContainer1.TabIndex = 13;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(8, 278);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(390, 173);
            this.listBox1.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 6);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(398, 265);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Time Spent";
            this.chart1.Titles.Add(title1);
            // 
            // lblPercentCompleteByDeadline
            // 
            this.lblPercentCompleteByDeadline.AutoSize = true;
            this.lblPercentCompleteByDeadline.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentCompleteByDeadline.Location = new System.Drawing.Point(39, 61);
            this.lblPercentCompleteByDeadline.Name = "lblPercentCompleteByDeadline";
            this.lblPercentCompleteByDeadline.Size = new System.Drawing.Size(88, 39);
            this.lblPercentCompleteByDeadline.TabIndex = 1;
            this.lblPercentCompleteByDeadline.Text = "100%";
            this.lblPercentCompleteByDeadline.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(133, 339);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "spent in";
            // 
            // lblAverageTimeOnTasks
            // 
            this.lblAverageTimeOnTasks.AutoSize = true;
            this.lblAverageTimeOnTasks.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageTimeOnTasks.Location = new System.Drawing.Point(47, 190);
            this.lblAverageTimeOnTasks.Name = "lblAverageTimeOnTasks";
            this.lblAverageTimeOnTasks.Size = new System.Drawing.Size(81, 39);
            this.lblAverageTimeOnTasks.TabIndex = 2;
            this.lblAverageTimeOnTasks.Text = "8 hrs";
            this.lblAverageTimeOnTasks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(133, 352);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "meetings";
            // 
            // lblMeetingHours
            // 
            this.lblMeetingHours.AutoSize = true;
            this.lblMeetingHours.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeetingHours.Location = new System.Drawing.Point(15, 326);
            this.lblMeetingHours.Name = "lblMeetingHours";
            this.lblMeetingHours.Size = new System.Drawing.Size(113, 39);
            this.lblMeetingHours.TabIndex = 3;
            this.lblMeetingHours.Text = "160 hrs";
            this.lblMeetingHours.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(209, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "average";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "of tasks";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(207, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "per task";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "spent on";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "on time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "in total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "completed";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 506);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "You Complete Me Application";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.calendarTab.ResumeLayout(false);
            this.scorecardTab.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem completedTaskReportToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage calendarTab;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TabPage scorecardTab;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblMeetingHours;
        private System.Windows.Forms.Label lblAverageTimeOnTasks;
        private System.Windows.Forms.Label lblPercentCompleteByDeadline;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBox1;
    }
}