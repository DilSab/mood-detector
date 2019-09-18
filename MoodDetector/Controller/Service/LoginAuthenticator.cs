using System.Data;
using System.Data.SqlClient;

namespace Controller.Service
{
    public class LoginAuthenticator : ILoginAuthenticator
    {
        public bool IsLoginCorrect(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MoodDetectorDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT COUNT(*) FROM LoginInfo WHERE Username='" + username + "' AND Password='" + password + "'", connection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                return dataTable.Rows[0][0].ToString() == "1" ? true : false;
            }
        }
    }
}
