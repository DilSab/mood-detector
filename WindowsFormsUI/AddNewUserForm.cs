using System;
using System.Windows.Forms;
using ControllerProject.Service;
using Model.Entity;

namespace WindowsFormsUI
{
    public partial class AddNewUserForm : Form
    {
        private IUserService _userService;
        //private IRegisterAuthenticator _registerAuthenticator;

        public AddNewUserForm(IUserService userService)
        {
            _userService = userService;
            //_registerAuthenticator = new RegisterAuthenticator();
            InitializeComponent();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            //var addUser = new UserWithLogin(
            //    usernameTextBox.Text,
            //    passwordTextBox.Text,
            //    emailTextBox.Text,
            //    firstnameTextBox.Text,
            //    lastnameTextBox.Text,
            //    accessRightsTextBox.Text
            //);
            //if (!_registerAuthenticator.IsRegisterDataCorrect(addUser))
            //{
            //    MessageBox.Show("Check your input");
            //    return;
            //}
            //_userService.AddNewUser(addUser);
            this.Close();
        }
    }
}
