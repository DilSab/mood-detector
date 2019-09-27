using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Controller.Service;

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
            _userService.AddNewUser(
                firstnameTextBox.Text,
                lastnameTextBox.Text,
                accessRightsTextBox.Text
            );
            this.Close();
        }
    }
}
