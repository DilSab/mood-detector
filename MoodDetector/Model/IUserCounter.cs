using System.Data;

namespace Model
{
    public interface IUserCounter
    {
        int GetUserCount(string username, string password);
    }
}