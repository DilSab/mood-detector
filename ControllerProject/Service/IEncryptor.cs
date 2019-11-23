namespace ControllerProject.Service
{
    public interface IEncryptor
    {
        Hash GetHash(string password);
        bool IsHashMathing(string saltedHash, string password, string salt);
    }
}
