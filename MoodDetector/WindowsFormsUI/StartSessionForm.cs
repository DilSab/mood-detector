using Controller.Service;
using Model;
using Model.Entity;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class StartSessionForm : Form
    {
        private User user;
        private IMoodService _moodService;
        private UserForm userForm;

        public StartSessionForm(User user, IMoodService moodService, UserForm userForm)
        {
            this.userForm = userForm;
            this.user = user;
            _moodService = moodService;
            InitializeComponent();

            userInfoLabel.Text = "Hello " + user.Firstname + " " + user.Lastname;
        }        

        private void startSessionButton_Click(object sender, System.EventArgs e)
        {
            SessionInfo sessionInfo = new SessionInfo
            {
                User = this.user,
                Subject = subjectTextBox.Text,
                Class = classTextBox.Text,
                Comments = commentsTextBox.Text,
                DateTime = dateTimePicker.Value,
                MessageSeen = 0
                
            };

            int sessionId = _moodService.AddSession(sessionInfo);
            SessionForm sessionForm = new SessionForm(sessionId, _moodService, userForm);
            sessionForm.Show();
            this.Close();
        }
    }
}
