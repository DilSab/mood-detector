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

        public SessionForm(SessionInfo sessionInfo, IMoodService moodService)
        {
            this.sessionInfo = sessionInfo;
            _moodService = moodService;
            InitializeComponent();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;

                AffectivaService affectivaService = new AffectivaService();
                Dictionary<string, float> emotions;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFileName = openFileDialog.FileName;

                    affectivaService.ProcessPhoto(selectedFileName);
                    emotions = affectivaService.GetEmotions();

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
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
