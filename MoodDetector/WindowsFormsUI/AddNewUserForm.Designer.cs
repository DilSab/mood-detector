namespace WindowsFormsUI
{
    partial class AddNewUserForm
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
            this.firstnameTextBox = new System.Windows.Forms.TextBox();
            this.lastnameTextBox = new System.Windows.Forms.TextBox();
            this.accessRightsTextBox = new System.Windows.Forms.TextBox();
            this.firstnameLabel = new System.Windows.Forms.Label();
            this.lastnameLabel = new System.Windows.Forms.Label();
            this.accessRightsLabel = new System.Windows.Forms.Label();
            this.addUserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstnameTextBox
            // 
            this.firstnameTextBox.Location = new System.Drawing.Point(220, 40);
            this.firstnameTextBox.Name = "firstnameTextBox";
            this.firstnameTextBox.Size = new System.Drawing.Size(100, 20);
            this.firstnameTextBox.TabIndex = 0;
            // 
            // lastnameTextBox
            // 
            this.lastnameTextBox.Location = new System.Drawing.Point(220, 80);
            this.lastnameTextBox.Name = "lastnameTextBox";
            this.lastnameTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastnameTextBox.TabIndex = 1;
            // 
            // accessRightsTextBox
            // 
            this.accessRightsTextBox.Location = new System.Drawing.Point(220, 120);
            this.accessRightsTextBox.Name = "accessRightsTextBox";
            this.accessRightsTextBox.Size = new System.Drawing.Size(100, 20);
            this.accessRightsTextBox.TabIndex = 2;
            // 
            // firstnameLabel
            // 
            this.firstnameLabel.AutoSize = true;
            this.firstnameLabel.Location = new System.Drawing.Point(120, 43);
            this.firstnameLabel.Name = "firstnameLabel";
            this.firstnameLabel.Size = new System.Drawing.Size(52, 13);
            this.firstnameLabel.TabIndex = 3;
            this.firstnameLabel.Text = "Firstname";
            // 
            // lastnameLabel
            // 
            this.lastnameLabel.AutoSize = true;
            this.lastnameLabel.Location = new System.Drawing.Point(120, 83);
            this.lastnameLabel.Name = "lastnameLabel";
            this.lastnameLabel.Size = new System.Drawing.Size(53, 13);
            this.lastnameLabel.TabIndex = 4;
            this.lastnameLabel.Text = "Lastname";
            // 
            // accessRightsLabel
            // 
            this.accessRightsLabel.AutoSize = true;
            this.accessRightsLabel.Location = new System.Drawing.Point(120, 123);
            this.accessRightsLabel.Name = "accessRightsLabel";
            this.accessRightsLabel.Size = new System.Drawing.Size(75, 13);
            this.accessRightsLabel.TabIndex = 5;
            this.accessRightsLabel.Text = "Access Rights";
            // 
            // addUserButton
            // 
            this.addUserButton.Location = new System.Drawing.Point(180, 177);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(75, 23);
            this.addUserButton.TabIndex = 6;
            this.addUserButton.Text = "Add user";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.AddUserButton_Click);
            // 
            // AddNewUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 311);
            this.Controls.Add(this.addUserButton);
            this.Controls.Add(this.accessRightsLabel);
            this.Controls.Add(this.lastnameLabel);
            this.Controls.Add(this.firstnameLabel);
            this.Controls.Add(this.accessRightsTextBox);
            this.Controls.Add(this.lastnameTextBox);
            this.Controls.Add(this.firstnameTextBox);
            this.Name = "AddNewUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mood Detector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstnameTextBox;
        private System.Windows.Forms.TextBox lastnameTextBox;
        private System.Windows.Forms.TextBox accessRightsTextBox;
        private System.Windows.Forms.Label firstnameLabel;
        private System.Windows.Forms.Label lastnameLabel;
        private System.Windows.Forms.Label accessRightsLabel;
        private System.Windows.Forms.Button addUserButton;
    }
}