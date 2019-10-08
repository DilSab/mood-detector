using Controller.Service;
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

namespace WindowsFormsUI
{
    public partial class UserForm : Form
    {
        private User user;
        private IMoodService _moodService;

        public UserForm(User user, IMoodService moodService)
        {
            this.user = user;
            _moodService = moodService;
            InitializeComponent();
        }

        private void startNewSessionButton_Click(object sender, EventArgs e)
        {
            StartSessionForm startSessionForm = new StartSessionForm(user, _moodService);
            startSessionForm.ShowDialog();
        }

        private void showEmotionsButton_Click(object sender, EventArgs e)
        {
            ChartForm chartForm = new ChartForm(user, _moodService);
            chartForm.ShowDialog();
        }
    }
}
