using Controller.Service;
using Model;
using Model.Entity;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace WindowsFormsUI
{
    public partial class StartSessionForm : Form
    {
        private User user;
        private IMoodService _moodService;

        public StartSessionForm(User user, IMoodService moodService)
        {
            this.user = user;
            _moodService = moodService;
            InitializeComponent();

            userInfoLabel.Text = "Hello " + user.Firstname + " " + user.Lastname;
            LoadMessages();
        }

        private void LoadMessages()
        {
            ILearningService _learningService = new LearningService(user, _moodService);

            Tuple<string, int> joyMessage = _learningService.GetJoyMessage();
            if (joyMessage.Item1 != "") PrintMessage(joyMessage);

            Tuple<string, int> angerMessage = _learningService.GetAngerMessage();
            if (angerMessage.Item1 != "") PrintMessage(angerMessage);
        }

        private void PrintMessage(Tuple<string, int> message)
        {
            newsessionGroupBox.Location = new Point(newsessionGroupBox.Location.X, newsessionGroupBox.Location.Y + 20);
            FlowLayoutPanel pnl = new FlowLayoutPanel()
            {
                Height = 20,
                Width = this.Width,
                Location = new Point(newsessionGroupBox.Location.X, newsessionGroupBox.Location.Y - 20),
                Tag = message.Item2
            };
            pnl.Controls.Add(new Label()
            {
                Text = message.Item1,
                AutoSize = true
            });
            LinkLabel llbl = new LinkLabel()
            {
                Text = "Link",
                Tag = pnl,
                AutoSize = true
            };
            llbl.Click += Llbl_Click;
            pnl.Controls.Add(llbl);
            this.Size = new Size(Size.Width, Size.Height + 20);
            this.Controls.Add(pnl);

        }

        private void Llbl_Click(object sender, EventArgs e)
        {
            LinkLabel llbl = (LinkLabel)sender;
            FlowLayoutPanel parentPanel = (FlowLayoutPanel)llbl.Tag;
            this.Controls.Remove(parentPanel);
            this.Size = new Size(Size.Width, Size.Height - 20);
            foreach(Control i in Controls)
            {
                if (!(i is FlowLayoutPanel)&& !(i is GroupBox)) continue;
                if (i.Location.Y > parentPanel.Location.Y)
                {
                    i.Location = new Point(i.Location.X, i.Location.Y - 20);
                }
            }
            _moodService.UpdateSessionMessageStatus((int)parentPanel.Tag);
        }

        private void startSessionButton_Click(object sender, System.EventArgs e)
        {
            SessionInfo sessionInfo = new SessionInfo
            {
                User = this.user,
                Subject = subjectTextBox.Text,
                Class = classTextBox.Text,
                Comments = commentsTextBox.Text,
                DateTime = dateTimePicker.Value
            };
            SessionForm sessionForm = new SessionForm(sessionInfo, _moodService);
            sessionForm.Show();
            this.Close();
        }
    }
}
