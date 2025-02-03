using System.Security.Cryptography;
using System.Text;

namespace FlopyBirbServer
{
    public class PasswordManager
    {
        readonly int keySize = 64;
        readonly int iterations = 350000;
        HashAlgorithmName hashAlgorithmName = HashAlgorithmName.SHA512;

        public PasswordManager()
        { }

        public PasswordManager(int keySize, int iterations, HashAlgorithmName hashAlgorithmName)
        {
            this.keySize = keySize;
            this.iterations = iterations;
            this.hashAlgorithmName = hashAlgorithmName;
        }

        public string HashPassword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, iterations, hashAlgorithmName, keySize);

            return Convert.ToHexString(hash);
        }

        public bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithmName, keySize);

            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }
    }
}
