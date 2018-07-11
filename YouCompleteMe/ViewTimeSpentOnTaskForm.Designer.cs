﻿namespace YouCompleteMe
{
    partial class ViewTimeSpentOnTaskForm
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TimeSpentDataSet = new YouCompleteMe.TimeSpentDataSet();
            this.tasksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tasksTableAdapter = new YouCompleteMe.TimeSpentDataSetTableAdapters.tasksTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.TimeSpentDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "TimeDataSpent";
            reportDataSource1.Value = this.tasksBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "YouCompleteMe.TimeSpentReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(934, 584);
            this.reportViewer1.TabIndex = 0;
            // 
            // TimeSpentDataSet
            // 
            this.TimeSpentDataSet.DataSetName = "TimeSpentDataSet";
            this.TimeSpentDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tasksBindingSource
            // 
            this.tasksBindingSource.DataMember = "tasks";
            this.tasksBindingSource.DataSource = this.TimeSpentDataSet;
            // 
            // tasksTableAdapter
            // 
            this.tasksTableAdapter.ClearBeforeFill = true;
            // 
            // ViewTimeSpentOnTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 584);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ViewTimeSpentOnTaskForm";
            this.Text = "Time Report";
            this.Load += new System.EventHandler(this.ViewTimeSpentOnTaskForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TimeSpentDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tasksBindingSource;
        private TimeSpentDataSet TimeSpentDataSet;
        private TimeSpentDataSetTableAdapters.tasksTableAdapter tasksTableAdapter;
    }
}