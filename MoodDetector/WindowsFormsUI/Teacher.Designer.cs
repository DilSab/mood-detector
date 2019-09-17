namespace WindowsFormsUI
{
    partial class teacherForm
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
            this.classroomLabel = new System.Windows.Forms.Label();
            this.classroomTextBox = new System.Windows.Forms.TextBox();
            this.classLabel = new System.Windows.Forms.Label();
            this.classTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.commentsTextBox = new System.Windows.Forms.TextBox();
            this.newsessionGroupBox = new System.Windows.Forms.GroupBox();
            this.getfeedbackGroupBox = new System.Windows.Forms.GroupBox();
            this.selectLabel = new System.Windows.Forms.Label();
            this.selectComboBox = new System.Windows.Forms.ComboBox();
            this.getButton = new System.Windows.Forms.Button();
            this.newsessionGroupBox.SuspendLayout();
            this.getfeedbackGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // classroomLabel
            // 
            this.classroomLabel.AutoSize = true;
            this.classroomLabel.Location = new System.Drawing.Point(131, 18);
            this.classroomLabel.Name = "classroomLabel";
            this.classroomLabel.Size = new System.Drawing.Size(74, 17);
            this.classroomLabel.TabIndex = 0;
            this.classroomLabel.Text = "Classroom";
            // 
            // classroomTextBox
            // 
            this.classroomTextBox.Location = new System.Drawing.Point(211, 15);
            this.classroomTextBox.Name = "classroomTextBox";
            this.classroomTextBox.Size = new System.Drawing.Size(100, 22);
            this.classroomTextBox.TabIndex = 1;
            // 
            // classLabel
            // 
            this.classLabel.AutoSize = true;
            this.classLabel.Location = new System.Drawing.Point(163, 46);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(42, 17);
            this.classLabel.TabIndex = 2;
            this.classLabel.Text = "Class";
            // 
            // classTextBox
            // 
            this.classTextBox.Location = new System.Drawing.Point(211, 43);
            this.classTextBox.Name = "classTextBox";
            this.classTextBox.Size = new System.Drawing.Size(100, 22);
            this.classTextBox.TabIndex = 3;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(181, 217);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(132, 23);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start new session";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // commentsLabel
            // 
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.Location = new System.Drawing.Point(10, 77);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(74, 17);
            this.commentsLabel.TabIndex = 5;
            this.commentsLabel.Text = "Comments";
            // 
            // commentsTextBox
            // 
            this.commentsTextBox.Location = new System.Drawing.Point(13, 97);
            this.commentsTextBox.Multiline = true;
            this.commentsTextBox.Name = "commentsTextBox";
            this.commentsTextBox.Size = new System.Drawing.Size(300, 114);
            this.commentsTextBox.TabIndex = 6;
            // 
            // newsessionGroupBox
            // 
            this.newsessionGroupBox.Controls.Add(this.classroomLabel);
            this.newsessionGroupBox.Controls.Add(this.commentsTextBox);
            this.newsessionGroupBox.Controls.Add(this.classroomTextBox);
            this.newsessionGroupBox.Controls.Add(this.commentsLabel);
            this.newsessionGroupBox.Controls.Add(this.classLabel);
            this.newsessionGroupBox.Controls.Add(this.startButton);
            this.newsessionGroupBox.Controls.Add(this.classTextBox);
            this.newsessionGroupBox.Location = new System.Drawing.Point(12, 12);
            this.newsessionGroupBox.Name = "newsessionGroupBox";
            this.newsessionGroupBox.Size = new System.Drawing.Size(321, 248);
            this.newsessionGroupBox.TabIndex = 7;
            this.newsessionGroupBox.TabStop = false;
            this.newsessionGroupBox.Text = "New Session";
            // 
            // getfeedbackGroupBox
            // 
            this.getfeedbackGroupBox.Controls.Add(this.getButton);
            this.getfeedbackGroupBox.Controls.Add(this.selectComboBox);
            this.getfeedbackGroupBox.Controls.Add(this.selectLabel);
            this.getfeedbackGroupBox.Location = new System.Drawing.Point(349, 12);
            this.getfeedbackGroupBox.Name = "getfeedbackGroupBox";
            this.getfeedbackGroupBox.Size = new System.Drawing.Size(255, 248);
            this.getfeedbackGroupBox.TabIndex = 8;
            this.getfeedbackGroupBox.TabStop = false;
            this.getfeedbackGroupBox.Text = "Get Event Feedback";
            // 
            // selectLabel
            // 
            this.selectLabel.AutoSize = true;
            this.selectLabel.Location = new System.Drawing.Point(6, 34);
            this.selectLabel.Name = "selectLabel";
            this.selectLabel.Size = new System.Drawing.Size(47, 17);
            this.selectLabel.TabIndex = 0;
            this.selectLabel.Text = "Select";
            // 
            // selectComboBox
            // 
            this.selectComboBox.FormattingEnabled = true;
            this.selectComboBox.Location = new System.Drawing.Point(59, 31);
            this.selectComboBox.Name = "selectComboBox";
            this.selectComboBox.Size = new System.Drawing.Size(190, 24);
            this.selectComboBox.TabIndex = 1;
            // 
            // getButton
            // 
            this.getButton.Location = new System.Drawing.Point(174, 217);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(75, 23);
            this.getButton.TabIndex = 2;
            this.getButton.Text = "Get";
            this.getButton.UseVisualStyleBackColor = true;
            // 
            // teacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 279);
            this.Controls.Add(this.getfeedbackGroupBox);
            this.Controls.Add(this.newsessionGroupBox);
            this.Name = "teacherForm";
            this.Text = "Teacher";
            this.newsessionGroupBox.ResumeLayout(false);
            this.newsessionGroupBox.PerformLayout();
            this.getfeedbackGroupBox.ResumeLayout(false);
            this.getfeedbackGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label classroomLabel;
        private System.Windows.Forms.TextBox classroomTextBox;
        private System.Windows.Forms.Label classLabel;
        private System.Windows.Forms.TextBox classTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.TextBox commentsTextBox;
        private System.Windows.Forms.GroupBox newsessionGroupBox;
        private System.Windows.Forms.GroupBox getfeedbackGroupBox;
        private System.Windows.Forms.Button getButton;
        private System.Windows.Forms.ComboBox selectComboBox;
        private System.Windows.Forms.Label selectLabel;
    }
}