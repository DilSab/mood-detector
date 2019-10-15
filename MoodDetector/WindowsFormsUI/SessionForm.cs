using Controller.Service;
using Controller.Affectiva;
using Model.Entity;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

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
                    Dictionary<string, float> emotions = _affectivaService.GetEmotions();

                    MoodCollection moodCollection = new MoodCollection
                    {
                        Anger = emotions["anger"],
                        Contempt = emotions["contempt"],
                        Disgust = emotions["disgust"],
                        Engagement = emotions["engagement"],
                        Fear = emotions["fear"],
                        Joy = emotions["joy"],
                        Sadness = emotions["sadness"],
                        Suprise = emotions["surprise"],
                        Valence = emotions["valence"]
                    };

                    AddMood addMood = new AddMood
                    {
                        MoodCollection = moodCollection,
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
