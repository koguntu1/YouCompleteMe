namespace YouCompleteMe.Views
{
    partial class childTasksForm
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddNewSubTask = new System.Windows.Forms.Button();
            this.listSubTaskGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.todateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnDeleteSubtask = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listSubTaskGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(21, 415);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 33);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "Search Sub Tasks By Created Date";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(555, 415);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(116, 33);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "Cancel";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddNewSubTask
            // 
            this.btnAddNewSubTask.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewSubTask.Location = new System.Drawing.Point(145, 415);
            this.btnAddNewSubTask.Name = "btnAddNewSubTask";
            this.btnAddNewSubTask.Size = new System.Drawing.Size(184, 33);
            this.btnAddNewSubTask.TabIndex = 16;
            this.btnAddNewSubTask.Text = "Create New Sub Task";
            this.btnAddNewSubTask.UseVisualStyleBackColor = true;
            this.btnAddNewSubTask.Click += new System.EventHandler(this.btnAddNewSubTask_Click);
            // 
            // listSubTaskGridView
            // 
            this.listSubTaskGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listSubTaskGridView.Location = new System.Drawing.Point(21, 107);
            this.listSubTaskGridView.MultiSelect = false;
            this.listSubTaskGridView.Name = "listSubTaskGridView";
            this.listSubTaskGridView.ReadOnly = true;
            this.listSubTaskGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listSubTaskGridView.Size = new System.Drawing.Size(650, 292);
            this.listSubTaskGridView.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(386, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "To Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "From Date :";
            // 
            // todateTimePicker
            // 
            this.todateTimePicker.Location = new System.Drawing.Point(469, 66);
            this.todateTimePicker.Name = "todateTimePicker";
            this.todateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.todateTimePicker.TabIndex = 54;
            // 
            // fromdateTimePicker
            // 
            this.fromdateTimePicker.Location = new System.Drawing.Point(129, 65);
            this.fromdateTimePicker.Name = "fromdateTimePicker";
            this.fromdateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.fromdateTimePicker.TabIndex = 53;
            this.fromdateTimePicker.Value = new System.DateTime(2018, 7, 21, 0, 0, 0, 0);
            // 
            // btnDeleteSubtask
            // 
            this.btnDeleteSubtask.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSubtask.Location = new System.Drawing.Point(350, 415);
            this.btnDeleteSubtask.Name = "btnDeleteSubtask";
            this.btnDeleteSubtask.Size = new System.Drawing.Size(184, 33);
            this.btnDeleteSubtask.TabIndex = 55;
            this.btnDeleteSubtask.Text = "Delete Sub Task";
            this.btnDeleteSubtask.UseVisualStyleBackColor = true;
            this.btnDeleteSubtask.Click += new System.EventHandler(this.btnDeleteSubtask_Click);
            // 
            // childTasksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 462);
            this.Controls.Add(this.btnDeleteSubtask);
            this.Controls.Add(this.todateTimePicker);
            this.Controls.Add(this.fromdateTimePicker);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAddNewSubTask);
            this.Controls.Add(this.listSubTaskGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "childTasksForm";
            this.Text = "Sub Tasks";
            ((System.ComponentModel.ISupportInitialize)(this.listSubTaskGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAddNewSubTask;
        private System.Windows.Forms.DataGridView listSubTaskGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker todateTimePicker;
        private System.Windows.Forms.DateTimePicker fromdateTimePicker;
        private System.Windows.Forms.Button btnDeleteSubtask;
    }
}