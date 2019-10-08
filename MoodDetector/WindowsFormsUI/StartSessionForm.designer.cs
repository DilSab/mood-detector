namespace WindowsFormsUI
{
    partial class StartSessionForm
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
            this.subjectLabel = new System.Windows.Forms.Label();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateAndTimeLabel = new System.Windows.Forms.Label();
            this.startSessionButton = new System.Windows.Forms.Button();
            this.newsessionGroupBox.SuspendLayout();
            this.getfeedbackGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Location = new System.Drawing.Point(111, 15);
            this.subjectLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(43, 13);
            this.subjectLabel.TabIndex = 0;
            this.subjectLabel.Text = "Subject";
            this.subjectLabel.UseWaitCursor = true;
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(158, 12);
            this.subjectTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(76, 20);
            this.subjectTextBox.TabIndex = 1;
            this.subjectTextBox.UseWaitCursor = true;
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
            this.classLabel.UseWaitCursor = true;
            // 
            // classTextBox
            // 
            this.classTextBox.Location = new System.Drawing.Point(158, 35);
            this.classTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.classTextBox.Name = "classTextBox";
            this.classTextBox.Size = new System.Drawing.Size(76, 20);
            this.classTextBox.TabIndex = 3;
            this.classTextBox.UseWaitCursor = true;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(136, 176);
            this.startButton.Margin = new System.Windows.Forms.Padding(2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(99, 19);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start new session";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.UseWaitCursor = true;
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
            this.commentsLabel.UseWaitCursor = true;
            // 
            // commentsTextBox
            // 
            this.commentsTextBox.Location = new System.Drawing.Point(10, 79);
            this.commentsTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.commentsTextBox.Multiline = true;
            this.commentsTextBox.Name = "commentsTextBox";
            this.commentsTextBox.Size = new System.Drawing.Size(226, 93);
            this.commentsTextBox.TabIndex = 6;
            this.commentsTextBox.UseWaitCursor = true;
            // 
            // newsessionGroupBox
            // 
            this.newsessionGroupBox.Controls.Add(this.startSessionButton);
            this.newsessionGroupBox.Controls.Add(this.dateAndTimeLabel);
            this.newsessionGroupBox.Controls.Add(this.subjectLabel);
            this.newsessionGroupBox.Controls.Add(this.commentsTextBox);
            this.newsessionGroupBox.Controls.Add(this.subjectTextBox);
            this.newsessionGroupBox.Controls.Add(this.commentsLabel);
            this.newsessionGroupBox.Controls.Add(this.classLabel);
            this.newsessionGroupBox.Controls.Add(this.startButton);
            this.newsessionGroupBox.Controls.Add(this.classTextBox);
            this.newsessionGroupBox.Location = new System.Drawing.Point(9, 35);
            this.newsessionGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.newsessionGroupBox.Name = "newsessionGroupBox";
            this.newsessionGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.newsessionGroupBox.Size = new System.Drawing.Size(449, 177);
            this.newsessionGroupBox.TabIndex = 7;
            this.newsessionGroupBox.TabStop = false;
            this.newsessionGroupBox.Text = "New Session";
            this.newsessionGroupBox.UseWaitCursor = true;
            // 
            // getfeedbackGroupBox
            // 
            this.getfeedbackGroupBox.Controls.Add(this.getButton);
            this.getfeedbackGroupBox.Controls.Add(this.selectComboBox);
            this.getfeedbackGroupBox.Controls.Add(this.selectLabel);
            this.getfeedbackGroupBox.Location = new System.Drawing.Point(254, 114);
            this.getfeedbackGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.getfeedbackGroupBox.Name = "getfeedbackGroupBox";
            this.getfeedbackGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.getfeedbackGroupBox.Size = new System.Drawing.Size(212, 59);
            this.getfeedbackGroupBox.TabIndex = 8;
            this.getfeedbackGroupBox.TabStop = false;
            this.getfeedbackGroupBox.Text = "Get Event Feedback";
            this.getfeedbackGroupBox.UseWaitCursor = true;
            // 
            // getButton
            // 
            this.getButton.Location = new System.Drawing.Point(130, 176);
            this.getButton.Margin = new System.Windows.Forms.Padding(2);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(56, 19);
            this.getButton.TabIndex = 2;
            this.getButton.Text = "Get";
            this.getButton.UseVisualStyleBackColor = true;
            this.getButton.UseWaitCursor = true;
            // 
            // selectComboBox
            // 
            this.selectComboBox.FormattingEnabled = true;
            this.selectComboBox.Location = new System.Drawing.Point(44, 25);
            this.selectComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.selectComboBox.Name = "selectComboBox";
            this.selectComboBox.Size = new System.Drawing.Size(144, 21);
            this.selectComboBox.TabIndex = 1;
            this.selectComboBox.UseWaitCursor = true;
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
            this.selectLabel.UseWaitCursor = true;
            // 
            // userInfoLabel
            // 
            this.userInfoLabel.AutoSize = true;
            this.userInfoLabel.Location = new System.Drawing.Point(12, 9);
            this.userInfoLabel.Name = "userInfoLabel";
            this.userInfoLabel.Size = new System.Drawing.Size(49, 13);
            this.userInfoLabel.TabIndex = 9;
            this.userInfoLabel.Text = "User info";
            this.userInfoLabel.UseWaitCursor = true;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(254, 70);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(199, 20);
            this.dateTimePicker.TabIndex = 3;
            // 
            // dateAndTimeLabel
            // 
            this.dateAndTimeLabel.AutoSize = true;
            this.dateAndTimeLabel.Location = new System.Drawing.Point(245, 15);
            this.dateAndTimeLabel.Name = "dateAndTimeLabel";
            this.dateAndTimeLabel.Size = new System.Drawing.Size(77, 13);
            this.dateAndTimeLabel.TabIndex = 7;
            this.dateAndTimeLabel.Text = "Date and Time";
            // 
            // startSessionButton
            // 
            this.startSessionButton.Location = new System.Drawing.Point(353, 149);
            this.startSessionButton.Name = "startSessionButton";
            this.startSessionButton.Size = new System.Drawing.Size(80, 23);
            this.startSessionButton.TabIndex = 8;
            this.startSessionButton.Text = "Start Session";
            this.startSessionButton.UseVisualStyleBackColor = true;
            this.startSessionButton.Click += new System.EventHandler(this.startSessionButton_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 227);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.userInfoLabel);
            this.Controls.Add(this.getfeedbackGroupBox);
            this.Controls.Add(this.newsessionGroupBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configure Session";
            this.UseWaitCursor = true;
            this.newsessionGroupBox.ResumeLayout(false);
            this.newsessionGroupBox.PerformLayout();
            this.getfeedbackGroupBox.ResumeLayout(false);
            this.getfeedbackGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.TextBox subjectTextBox;
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
        private System.Windows.Forms.Label dateAndTimeLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button startSessionButton;
    }
}