namespace Controller
{
    public interface ILoginProcessor
    {
        bool ProcessLogin(string username, string password);
    }
}