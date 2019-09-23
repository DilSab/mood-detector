using System;
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
            bool loginCorrect = _loginProcessor.ProcessLogin(usernameTextBox.Text, passwordTextBox.Text);
            if (loginCorrect)
            {
                MessageBox.Show("Hello " + usernameTextBox.Text);
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
