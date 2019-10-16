using Controller.Service;
using Controller.Affectiva;
using Model.Entity;
using System;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class SessionForm : Form
    {
        private SessionInfo sessionInfo;
        private IMoodService _moodService;
        private AffectivaService _affectivaService;
        private UserForm userForm;

        public SessionForm(SessionInfo sessionInfo, IMoodService moodService, UserForm userForm)
        {
            this.userForm = userForm;
            this.sessionInfo = sessionInfo;
            _moodService = moodService;
            _affectivaService = new AffectivaService();
            _affectivaService.StartDetector();
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

                    _affectivaService.ProcessPhoto(selectedFileName);

                    AddMood addMood = new AddMood
                    {
                        MoodCollection = _affectivaService.GetMoodCollection(),
                        SessionInfo = this.sessionInfo
                    };

                    _moodService.AddClassMood(addMood);
                }
            }
            MessageBox.Show("Photo uploaded successfully!");
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            _affectivaService.StopDetector();
            userForm.LoadMessages();
            this.Close();
        }
    }
}
