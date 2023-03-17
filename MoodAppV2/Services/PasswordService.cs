using System;
using System.Security.Cryptography;
using System.Text;

namespace Services;
public class PasswordService
{
    private const int SaltSize = 16;
    private const int HashSize = 20;
    private const int Iterations = 10000;

    public bool ValidatePassword(string password, string pHashSalt, string pwd)
    {
        byte[] hashSalt = Convert.FromBase64String(pHashSalt);
        byte[] hash = Convert.FromBase64String(pwd);

        byte[] testHash = PBKDF2(password, hashSalt, Iterations, HashSize);

        return SlowEquals(hash, testHash);
    }

    public string HashPassword(string password)
    {
        byte[] salt = new byte[SaltSize];
        new RNGCryptoServiceProvider().GetBytes(salt);

        byte[] hash = PBKDF2(password, salt, Iterations, HashSize);

        return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
    }

    private byte[] PBKDF2(string password, byte[] salt, int iterations, int hashSize)
    {
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);

        return pbkdf2.GetBytes(hashSize);
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
