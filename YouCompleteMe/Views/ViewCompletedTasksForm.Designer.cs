﻿namespace YouCompleteMe.Views
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
            this.tasks1TableAdapter = new YouCompleteMe.CompletedTaskDataSetTableAdapters.tasks1TableAdapter();
            this.completedTaskDataSet = new YouCompleteMe.CompletedTaskDataSet();
            this.tasks1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.completedTaskDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasks1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tasks1TableAdapter
            // 
            this.tasks1TableAdapter.ClearBeforeFill = true;
            // 
            // completedTaskDataSet
            // 
            this.completedTaskDataSet.DataSetName = "CompletedTaskDataSet";
            this.completedTaskDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tasks1BindingSource
            // 
            this.tasks1BindingSource.DataMember = "tasks1";
            this.tasks1BindingSource.DataSource = this.completedTaskDataSet;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tasks1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "YouCompleteMe.CompletedTasksReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(950, 623);
            this.reportViewer1.TabIndex = 0;
            // 
            // ViewCompletedTasksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 623);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ViewCompletedTasksForm";
            this.Text = "Completed Tasks";
            this.Load += new System.EventHandler(this.ViewCompletedTasksForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.completedTaskDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasks1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CompletedTaskDataSetTableAdapters.tasks1TableAdapter tasks1TableAdapter;
        private CompletedTaskDataSet completedTaskDataSet;
        private System.Windows.Forms.BindingSource tasks1BindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}