using Controller.Service;
using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class ChartForm : Form
    {
        private User user;
        private IMoodService _moodService;

        public ChartForm(User user, IMoodService moodService)
        {
            this.user = user;
            _moodService = moodService;
            InitializeComponent();
        }

        private void loadDiagramButton_Click(object sender, EventArgs e)
        {
            List<Mood> moods;

            if (selectedDateCheckBox.Checked)
            {
                moods = _moodService.GetMoodsByDate(user, dateTimePicker.Value);
            }
            else
            {
                moods = _moodService.GetMoodsByDate(user);
            }
            if (moods != null)
            {
                PopulateDiagram(_moodService.GetMoodAverage(moods));
            }
        }

        private void PopulateDiagram(MoodCollection moodCollection)
        {
            chart.Series["Mood"].Points.Clear();

            chart.Series["Mood"].Points.AddXY("Anger", moodCollection.Anger);
            chart.Series["Mood"].Points.AddXY("Contempt", moodCollection.Contempt);
            chart.Series["Mood"].Points.AddXY("Disgust", moodCollection.Disgust);
            chart.Series["Mood"].Points.AddXY("Engagement", moodCollection.Engagement);
            chart.Series["Mood"].Points.AddXY("Fear", moodCollection.Fear);
            chart.Series["Mood"].Points.AddXY("Joy", moodCollection.Joy);
            chart.Series["Mood"].Points.AddXY("Sadness", moodCollection.Sadness);
            chart.Series["Mood"].Points.AddXY("Suprise", moodCollection.Suprise);
            chart.Series["Mood"].Points.AddXY("Valence", moodCollection.Valence);
        }
    }
}
