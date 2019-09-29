using Model;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class UserForm : Form
    {
        public UserForm(User user)
        {
            InitializeComponent();

            userInfoLabel.Text = "Hello " + user.Firstname + " " + user.Lastname;
        }
    }
}
