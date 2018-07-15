namespace YouCompleteMe.Views
{
    partial class ViewAverageTimePerTask
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
            this.averageTimeDataSet = new YouCompleteMe.AverageTimeDataSet();
            this.tasksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tasksTableAdapter = new YouCompleteMe.AverageTimeDataSetTableAdapters.tasksTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.averageTimeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // averageTimeDataSet
            // 
            this.averageTimeDataSet.DataSetName = "AverageTimeDataSet";
            this.averageTimeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tasksBindingSource
            // 
            this.tasksBindingSource.DataMember = "tasks";
            this.tasksBindingSource.DataSource = this.averageTimeDataSet;
            // 
            // tasksTableAdapter
            // 
            this.tasksTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tasksBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "YouCompleteMe.AverageTimeReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(934, 584);
            this.reportViewer1.TabIndex = 0;
            // 
            // ViewAverageTimePerTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 584);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ViewAverageTimePerTask";
            this.Text = "Average Time";
            this.Load += new System.EventHandler(this.ViewAverageTimePerTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.averageTimeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource tasksBindingSource;
        private AverageTimeDataSet averageTimeDataSet;
        private AverageTimeDataSetTableAdapters.tasksTableAdapter tasksTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}