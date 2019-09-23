using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsUI
{
    public partial class AppForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MoodDetectorDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public AppForm()
        {
            InitializeComponent();
        }

        private void AddTeacherButton_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("INSERT INTO Teacher(Firstname, Lastname, Subject) values('" + firstnameTextBox.Text + "','" + lastnameTextBox.Text + "','" + subjectTextBox.Text + "')", connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
        }
    }
}
