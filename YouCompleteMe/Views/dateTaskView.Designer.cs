namespace YouCompleteMe.Views
{
    partial class dateTaskView
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
            this.dateLabel = new System.Windows.Forms.Label();
            this.taskCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(13, 13);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(57, 20);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "label1";
            // 
            // taskCheckedListBox
            // 
            this.taskCheckedListBox.FormattingEnabled = true;
            this.taskCheckedListBox.Location = new System.Drawing.Point(12, 44);
            this.taskCheckedListBox.Name = "taskCheckedListBox";
            this.taskCheckedListBox.Size = new System.Drawing.Size(399, 394);
            this.taskCheckedListBox.TabIndex = 1;
            this.taskCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(389, 44);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 394);
            this.vScrollBar1.TabIndex = 2;
            // 
            // dateTaskView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.taskCheckedListBox);
            this.Controls.Add(this.dateLabel);
            this.Name = "dateTaskView";
            this.Text = "Task View";
            this.Load += new System.EventHandler(this.dateTaskView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.CheckedListBox taskCheckedListBox;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}