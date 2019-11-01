using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControllerProject.Service;

namespace WindowsFormsUI
{
    public partial class AdminForm : Form
    {
        private IUserService _userService;
        public AdminForm(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            AddNewUserForm addNewUserForm = new AddNewUserForm(_userService);
            addNewUserForm.ShowDialog();
        }
    }
}
