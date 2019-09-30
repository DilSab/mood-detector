using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Controller.Service;
using Model.Entity;

namespace WindowsFormsUI
{
    public partial class AddNewUserForm : Form
    {
        private IUserService _userService;

        public AddNewUserForm(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            var addUser = new AddUser(
                usernameTextBox.Text,
                passwordTextBox.Text,
                emailTextBox.Text,
                firstnameTextBox.Text,
                lastnameTextBox.Text,
                accessRightsTextBox.Text
            );

            _userService.AddNewUser(addUser);
            this.Close();
        }
    }
}
