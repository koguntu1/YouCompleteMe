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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.completedTaskDataSet = new YouCompleteMe.CompletedTaskDataSet();
            this.completedTaskDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.completedTaskDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.completedTaskDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(509, 310);
            this.dataGridView1.TabIndex = 0;
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
            // ViewCompletedTasksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 310);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ViewCompletedTasksForm";
            this.Text = "Completed Tasks";
            this.Load += new System.EventHandler(this.ViewCompletedTasksForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.completedTaskDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.completedTaskDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private CompletedTaskDataSet completedTaskDataSet;
        private System.Windows.Forms.BindingSource completedTaskDataSetBindingSource;
    }
}