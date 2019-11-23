using System;
using System.Security.Cryptography;

namespace ControllerProject.Service
{
    public class Encryptor : IEncryptor
    {
        private const int iterationsCount = 10000;
        private const int hashBytesCount = 64;
        private const int saltBytesCount = 28;

        public Hash GetHash(string password)
        {
            byte[] salt = new byte[saltBytesCount];
            using (RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider())
            {
                csp.GetBytes(salt);
            }

            byte[] saltedHashBytes = SaltHash(password, salt);

            Hash hash = new Hash(Convert.ToBase64String(salt), Convert.ToBase64String(saltedHashBytes));

            return hash;
        }

        public bool IsHashMathing(string saltedHash, string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] saltedHashBytes = Convert.FromBase64String(saltedHash);

            return SlowEquals(SaltHash(password, saltBytes), saltedHashBytes);
        }

        private byte[] SaltHash(string password, byte[] salt)
        {
            byte[] hashBytes = new byte[hashBytesCount];
            using (Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(password, salt, iterationsCount))
            {
                hashBytes = rfc.GetBytes(hashBytesCount);
            }

            return hashBytes;
        }

        private bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }

            return diff == 0;
        }
    }

    public struct Hash
    {
        public string Salt { get; private set; }
        public string SaltedHash { get; private set; }

        public Hash(string salt, string hash)
        {
            Salt = salt;
            SaltedHash = hash;
        }
    }
}
