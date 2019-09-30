using System;
using System.Windows.Forms;
using Controller;
using Controller.Service;

namespace WindowsFormsUI
{
    public partial class LoginForm : Form
    {
        private ILoginProcessor _loginProcessor;
        private IUserService _userService;

        public LoginForm(ILoginProcessor loginProcessor, IUserService userService)
        {
            _loginProcessor = loginProcessor;
            _userService = userService;
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            bool loginCorrect = _loginProcessor.ProcessLogin(usernameTextBox.Text, passwordTextBox.Text);
            if (loginCorrect)
            {
                var user = _userService.GetUser(usernameTextBox.Text);
                switch (user.AccessRights)
                {
                    case "Admin":
                        this.Hide();
                        AdminForm adminForm = new AdminForm(_userService);
                        adminForm.Show();
                        break;
                    case "Teacher":
                        this.Hide();
                        UserForm userForm = new UserForm(user);
                        userForm.Show();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please check username or password");
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
