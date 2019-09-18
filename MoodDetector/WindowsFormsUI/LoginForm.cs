using System;
using System.Security.Authentication;
using System.Windows.Forms;
using Controller;

namespace WindowsFormsUI
{
    public partial class LoginForm : Form
    {
        private ILoginProcessor _loginProcessor;
        public LoginForm(ILoginProcessor loginProcessor)
        {
            _loginProcessor = loginProcessor;
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                _loginProcessor.ProcessLogin(usernameTextBox.Text, passwordTextBox.Text);
                MessageBox.Show("Hello " + usernameTextBox.Text);
            }
            catch (AuthenticationException exception)
            {
                MessageBox.Show("Please check your username or password");
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
