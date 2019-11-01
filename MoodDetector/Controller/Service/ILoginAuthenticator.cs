namespace ControllerProject.Service
{
    public interface ILoginAuthenticator
    {
        bool IsLoginCorrect(string username, string password);
    }
}
