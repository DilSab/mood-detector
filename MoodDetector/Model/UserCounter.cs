using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserCounter : IUserCounter
    {
        public int GetUserCount(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MoodDetectorDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM LoginInfo WHERE Username=@username AND Password=@password", connection))
                {
                    connection.Open();
                    sqlCommand.Parameters.AddWithValue("@username", username);
                    sqlCommand.Parameters.AddWithValue("@password", password);
                    int userCount = (int) sqlCommand.ExecuteScalar();
                    connection.Close();

                    return userCount;
                }
            }
        }
    }
}
