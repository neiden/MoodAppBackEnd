using System;
using System.Text;
using System.Security.Cryptography;

namespace Services;

public class Services
{
    private const int SaltSize = 16;
    private const int HashSize = 20;
    private const int Iterations = 10000;

    public bool passwordVerification(string enteredPassword, string storedPasswordHash, string storedPasswordSalt)
    {
        byte[] salt = Convert.FromBase64String(storedPasswordSalt);
        byte[] hash = Convert.FromBase64String(storedPasswordHash);
        byte[] enteredPasswordHash = GeneratePasswordHash(enteredPassword, salt);
        return SlowEquals(hash, enteredPasswordHash);
    }

    public string GeneratePasswordHash(string password)
    {
        byte[] salt = GenerateSalt();
        byte[] hash = GeneratePasswordHash(password, salt);

        return $"{Convert.ToBase64String(hash)}:{Convert.ToBase64String(salt)}";
    }

    private byte[] GeneratePasswordHash(string password, byte[] salt)
    {            
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
        {
            return pbkdf2.GetBytes(HashSize);
        }
    }

    private byte[] GenerateSalt()        
    {
        byte[] salt = new byte[SaltSize];
        using (var random = new RNGCryptoServiceProvider())
        {
           random.GetBytes(salt);
        }
        return salt;
    }

    private bool SlowEquals(byte[] a, byte[] b)
    {
        uint diff = (uint)a.Length ^ (uint)b.Length;
        for (int i = 0; i < a.Length && i < b.Length; i++)
        {
            diff |= (uint)(a[i] ^ b[i]);
        }
        return diff == 0;
    }
}
