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
            this.startNewSessionButton = new System.Windows.Forms.Button();
            this.showEmotionsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startNewSessionButton
            // 
            this.startNewSessionButton.Location = new System.Drawing.Point(107, 138);
            this.startNewSessionButton.Name = "startNewSessionButton";
            this.startNewSessionButton.Size = new System.Drawing.Size(91, 41);
            this.startNewSessionButton.TabIndex = 0;
            this.startNewSessionButton.Text = "Start new session";
            this.startNewSessionButton.UseVisualStyleBackColor = true;
            this.startNewSessionButton.Click += new System.EventHandler(this.startNewSessionButton_Click);
            // 
            // showEmotionsButton
            // 
            this.showEmotionsButton.Location = new System.Drawing.Point(378, 138);
            this.showEmotionsButton.Name = "showEmotionsButton";
            this.showEmotionsButton.Size = new System.Drawing.Size(90, 41);
            this.showEmotionsButton.TabIndex = 1;
            this.showEmotionsButton.Text = "Show Emotion chart";
            this.showEmotionsButton.UseVisualStyleBackColor = true;
            this.showEmotionsButton.Click += new System.EventHandler(this.showEmotionsButton_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 287);
            this.Controls.Add(this.showEmotionsButton);
            this.Controls.Add(this.startNewSessionButton);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startNewSessionButton;
        private System.Windows.Forms.Button showEmotionsButton;
    }
}