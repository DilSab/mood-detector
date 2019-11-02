using ControllerProject.Service;
using System;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class SessionForm : Form
    {
        private readonly int sessionId;
        private readonly IMoodService _moodService;
        private readonly IDataGenerator _dataGenerator;
        private readonly UserForm userForm;

        public SessionForm(int sessionId, IMoodService moodService, UserForm userForm)
        {
            this.userForm = userForm;
            this.sessionId = sessionId;
            _moodService = moodService;
            _dataGenerator = new DataGenerator();
            InitializeComponent();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFileName = openFileDialog.FileName;

                    _moodService.AddMood(sessionId, _dataGenerator.GetRandomMoodCollection());
                }
            }
            MessageBox.Show("Photo uploaded successfully!");
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            userForm.LoadMessages();
            this.Close();
        }
    }
}
