namespace YouCompleteMe.Views
{
    partial class ViewCompletedTasksForm
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tasks1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.completedTaskDataSet = new YouCompleteMe.CompletedTaskDataSet();
            this.completedTaskDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tasks1TableAdapter1 = new YouCompleteMe.CompletedTaskDataSetTableAdapters.tasks1TableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tasks1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.completedTaskDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.completedTaskDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tasks1BindingSource
            // 
            this.tasks1BindingSource.DataMember = "tasks1";
            this.tasks1BindingSource.DataSource = this.completedTaskDataSet;
            // 
            // completedTaskDataSet
            // 
            this.completedTaskDataSet.DataSetName = "CompletedTaskDataSet";
            this.completedTaskDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // completedTaskDataSetBindingSource
            // 
            this.completedTaskDataSetBindingSource.DataSource = this.completedTaskDataSet;
            this.completedTaskDataSetBindingSource.Position = 0;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tasks1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "YouCompleteMe.Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 80);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(950, 543);
            this.reportViewer1.TabIndex = 0;
            // 
            // tasks1TableAdapter1
            // 
            this.tasks1TableAdapter1.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(658, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.closeOnClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(219, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.submitOnClick);
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(533, 25);
            this.endDate.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(200, 20);
            this.endDate.TabIndex = 7;
            this.endDate.Value = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(219, 25);
            this.startDate.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(200, 20);
            this.startDate.TabIndex = 6;
            this.startDate.Value = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(412, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Please Select a Date Range";
            // 
            // ViewCompletedTasksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 623);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ViewCompletedTasksForm";
            this.Text = "ViewCompletedTasksForm";
            ((System.ComponentModel.ISupportInitialize)(this.tasks1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.completedTaskDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.completedTaskDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource completedTaskDataSetBindingSource;
        private CompletedTaskDataSet completedTaskDataSet;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tasks1BindingSource;
        private CompletedTaskDataSetTableAdapters.tasks1TableAdapter tasks1TableAdapter1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Label label1;
    }
}