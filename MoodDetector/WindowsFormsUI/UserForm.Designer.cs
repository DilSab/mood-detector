namespace WindowsFormsUI
{
    partial class UserForm
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
            this.getButton = new System.Windows.Forms.Button();
            this.selectComboBox = new System.Windows.Forms.ComboBox();
            this.selectLabel = new System.Windows.Forms.Label();
            this.userInfoLabel = new System.Windows.Forms.Label();
            this.newsessionGroupBox.SuspendLayout();
            this.getfeedbackGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // classroomLabel
            // 
            this.classroomLabel.AutoSize = true;
            this.classroomLabel.Location = new System.Drawing.Point(98, 15);
            this.classroomLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.classroomLabel.Name = "classroomLabel";
            this.classroomLabel.Size = new System.Drawing.Size(55, 13);
            this.classroomLabel.TabIndex = 0;
            this.classroomLabel.Text = "Classroom";
            // 
            // classroomTextBox
            // 
            this.classroomTextBox.Location = new System.Drawing.Point(158, 12);
            this.classroomTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.classroomTextBox.Name = "classroomTextBox";
            this.classroomTextBox.Size = new System.Drawing.Size(76, 20);
            this.classroomTextBox.TabIndex = 1;
            // 
            // classLabel
            // 
            this.classLabel.AutoSize = true;
            this.classLabel.Location = new System.Drawing.Point(122, 37);
            this.classLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(32, 13);
            this.classLabel.TabIndex = 2;
            this.classLabel.Text = "Class";
            // 
            // classTextBox
            // 
            this.classTextBox.Location = new System.Drawing.Point(158, 35);
            this.classTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.classTextBox.Name = "classTextBox";
            this.classTextBox.Size = new System.Drawing.Size(76, 20);
            this.classTextBox.TabIndex = 3;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(136, 176);
            this.startButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(99, 19);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start new session";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // commentsLabel
            // 
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.Location = new System.Drawing.Point(8, 63);
            this.commentsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(56, 13);
            this.commentsLabel.TabIndex = 5;
            this.commentsLabel.Text = "Comments";
            // 
            // commentsTextBox
            // 
            this.commentsTextBox.Location = new System.Drawing.Point(10, 79);
            this.commentsTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.commentsTextBox.Multiline = true;
            this.commentsTextBox.Name = "commentsTextBox";
            this.commentsTextBox.Size = new System.Drawing.Size(226, 93);
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
            this.newsessionGroupBox.Location = new System.Drawing.Point(9, 35);
            this.newsessionGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.newsessionGroupBox.Name = "newsessionGroupBox";
            this.newsessionGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.newsessionGroupBox.Size = new System.Drawing.Size(241, 177);
            this.newsessionGroupBox.TabIndex = 7;
            this.newsessionGroupBox.TabStop = false;
            this.newsessionGroupBox.Text = "New Session";
            // 
            // getfeedbackGroupBox
            // 
            this.getfeedbackGroupBox.Controls.Add(this.getButton);
            this.getfeedbackGroupBox.Controls.Add(this.selectComboBox);
            this.getfeedbackGroupBox.Controls.Add(this.selectLabel);
            this.getfeedbackGroupBox.Location = new System.Drawing.Point(262, 35);
            this.getfeedbackGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.getfeedbackGroupBox.Name = "getfeedbackGroupBox";
            this.getfeedbackGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.getfeedbackGroupBox.Size = new System.Drawing.Size(191, 177);
            this.getfeedbackGroupBox.TabIndex = 8;
            this.getfeedbackGroupBox.TabStop = false;
            this.getfeedbackGroupBox.Text = "Get Event Feedback";
            // 
            // getButton
            // 
            this.getButton.Location = new System.Drawing.Point(130, 176);
            this.getButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(56, 19);
            this.getButton.TabIndex = 2;
            this.getButton.Text = "Get";
            this.getButton.UseVisualStyleBackColor = true;
            // 
            // selectComboBox
            // 
            this.selectComboBox.FormattingEnabled = true;
            this.selectComboBox.Location = new System.Drawing.Point(44, 25);
            this.selectComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectComboBox.Name = "selectComboBox";
            this.selectComboBox.Size = new System.Drawing.Size(144, 21);
            this.selectComboBox.TabIndex = 1;
            // 
            // selectLabel
            // 
            this.selectLabel.AutoSize = true;
            this.selectLabel.Location = new System.Drawing.Point(4, 28);
            this.selectLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectLabel.Name = "selectLabel";
            this.selectLabel.Size = new System.Drawing.Size(37, 13);
            this.selectLabel.TabIndex = 0;
            this.selectLabel.Text = "Select";
            // 
            // userInfoLabel
            // 
            this.userInfoLabel.AutoSize = true;
            this.userInfoLabel.Location = new System.Drawing.Point(12, 9);
            this.userInfoLabel.Name = "userInfoLabel";
            this.userInfoLabel.Size = new System.Drawing.Size(49, 13);
            this.userInfoLabel.TabIndex = 9;
            this.userInfoLabel.Text = "User info";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 227);
            this.Controls.Add(this.userInfoLabel);
            this.Controls.Add(this.getfeedbackGroupBox);
            this.Controls.Add(this.newsessionGroupBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserForm";
            this.Text = "Teacher";
            this.newsessionGroupBox.ResumeLayout(false);
            this.newsessionGroupBox.PerformLayout();
            this.getfeedbackGroupBox.ResumeLayout(false);
            this.getfeedbackGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label userInfoLabel;
    }
}