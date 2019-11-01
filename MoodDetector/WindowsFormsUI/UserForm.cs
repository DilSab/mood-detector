using ControllerProject.Service;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsUI
{
    public partial class UserForm : Form
    {
        private User user;
        private IMoodService _moodService;
        private int messagePosY;

        public UserForm(User user, IMoodService moodService)
        {
            this.user = user;
            _moodService = moodService;
            InitializeComponent();
            LoadMessages();
        }

        private void startNewSessionButton_Click(object sender, EventArgs e)
        {
            StartSessionForm startSessionForm = new StartSessionForm(user, _moodService, this);
            startSessionForm.ShowDialog();
        }

        private void showEmotionsButton_Click(object sender, EventArgs e)
        {
            ChartForm chartForm = new ChartForm(user, _moodService);
            chartForm.ShowDialog();
        }

        public void LoadMessages()
        {
            cleanMessages();
            ILearningService _learningService = new LearningService(user, _moodService);

            Tuple<string, int, int> joyMessage = _learningService.GetJoyMessage();
            if (joyMessage.Item1 != "") PrintMessage(joyMessage);

            Tuple<string, int, int> angerMessage = _learningService.GetAngerMessage();
            if (angerMessage.Item1 != "") PrintMessage(angerMessage);
        }

        private void cleanMessages()
        {
            messagePosY = 20;
            foreach (Control i in Controls)
            {
                if (!(i is FlowLayoutPanel)) continue;
                Controls.Remove(i);
            }
        }

        private void PrintMessage(Tuple<string, int, int> message)
        {
            FlowLayoutPanel pnl = new FlowLayoutPanel()
            {
                Height = 20,
                Width = this.Width,
                Location = new Point(20, messagePosY),
                Tag = new Tuple<int, int>(message.Item2, message.Item3)
            };
            pnl.Controls.Add(new Label()
            {
                Text = message.Item1,
                ForeColor = Color.Red,
                Font = new Font("Arial", 10),
                AutoSize = true
            });
            LinkLabel llbl = new LinkLabel()
            {
                Text = "Link",
                Tag = pnl,
                Font = new Font("Arial", 10),
                AutoSize = true
            };
            llbl.Click += Llbl_Click;
            pnl.Controls.Add(llbl);
            messagePosY += 20;
            this.Controls.Add(pnl);

        }
        private void Llbl_Click(object sender, EventArgs e)
        {
            LinkLabel llbl = (LinkLabel)sender;
            FlowLayoutPanel parentPanel = (FlowLayoutPanel)llbl.Tag;
            this.Controls.Remove(parentPanel);
            foreach (Control i in Controls)
            {
                if (!(i is FlowLayoutPanel)) continue;
                if (i.Location.Y > parentPanel.Location.Y)
                {
                    i.Location = new Point(i.Location.X, i.Location.Y - 20);
                }
            }
            Tuple<int, int> t = (Tuple<int, int>)parentPanel.Tag;
            _moodService.UpdateSessionMessageStatus(t.Item1, t.Item2);
        }
    }
}
