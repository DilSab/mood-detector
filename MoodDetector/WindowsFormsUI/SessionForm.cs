using Controller.Service;
using Model.Entity;
using System;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class SessionForm : Form
    {
        private SessionInfo sessionInfo;
        private IMoodService _moodService;

        public SessionForm(SessionInfo sessionInfo, IMoodService moodService)
        {
            this.sessionInfo = sessionInfo;
            _moodService = moodService;
            InitializeComponent();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;

                MoodCollection moodCollection = new MoodCollection
                {
                    Anger = 100.00,
                    Contempt = 100.00,
                    Disgust = 100.00,
                    Engagement = 100.00,
                    Fear = 100.00,
                    Joy = 100.00,
                    Sadness = 100.00,
                    Suprise = 100.00,
                    Valence = 100.00
                };

                AddMood addMood = new AddMood
                {
                    MoodCollection = moodCollection,
                    SessionInfo = this.sessionInfo
                };

                _moodService.AddClassMood(addMood);
            }
        }
    }
}
