using Controller.Service;
using Controller.Affectiva;
using Model.Entity;
using System;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class SessionForm : Form
    {
        private int sessionId;
        private IMoodService _moodService;
        private AffectivaService _affectivaService;
        private UserForm userForm;

        public SessionForm(int sessionId, IMoodService moodService, UserForm userForm)
        {
            this.userForm = userForm;
            this.sessionId = sessionId;
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

                    _moodService.AddMood(sessionId, _affectivaService.GetMoodCollection());
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
