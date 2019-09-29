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
            var addUser = new AddUser
            {
                Firstname = firstnameTextBox.Text,
                Lastname = lastnameTextBox.Text,
                AccessRights = accessRightsTextBox.Text,
                Username = usernameTextBox.Text,
                Password = passwordTextBox.Text,
                Email = emailTextBox.Text
            };

            _userService.AddNewUser(addUser);
            this.Close();
        }
    }
}
