namespace ControllerProject
{
    public interface ILoginProcessor
    {
        bool ProcessLogin(string username, string password);
    }
}