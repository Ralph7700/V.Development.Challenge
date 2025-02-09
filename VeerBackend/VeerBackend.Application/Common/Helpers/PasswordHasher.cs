using System.Security.Cryptography;

namespace VeerBackend.Application.Common.Helpers;

public static class PasswordHasher
{
    private const int SaltSize = 16; // 128 bits
    private const int HashSize = 32; // 256 bits
    private const int Iterations = 100000; // Number of iterations for PBKDF2

    public static (string Hash, string Salt) HashPassword(string password)
    {
        // Generate a random salt
        var salt = new byte[SaltSize];
        var rng = RandomNumberGenerator.Create();
        rng.GetBytes(salt);
        

        // Create hash
        var hash = HashPasswordWithSalt(password, salt);

        // Convert to base64 strings for storage
        var hashString = Convert.ToBase64String(hash);
        var saltString = Convert.ToBase64String(salt);

        return (hashString, saltString);
    }

    public static bool VerifyPassword(string password, string storedHash, string storedSalt)
    {
        try
        {
            // Convert stored salt and hash back to bytes
            var salt = Convert.FromBase64String(storedSalt);
            var hash = Convert.FromBase64String(storedHash);

            // Generate hash from password attempt
            var hashAttempt = HashPasswordWithSalt(password, salt);

            // Compare generated hash with stored hash
            return CryptographicOperations.FixedTimeEquals(hash, hashAttempt);
        }
        catch
        {
            return false;
        }
    }

    private static byte[] HashPasswordWithSalt(string password, byte[] salt)
    {
        var pbkdf2 = new Rfc2898DeriveBytes(
            password,
            salt,
            Iterations,
            HashAlgorithmName.SHA256);
        return pbkdf2.GetBytes(HashSize);
    }
}