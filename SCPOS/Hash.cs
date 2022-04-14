using System.Security.Cryptography;
using System.Text;

namespace SCPOS; 

public static class Hash {
    public static string GetHash(HashAlgorithm hashAlgorithm, string input)
    {
        byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        foreach (byte t in data) {
            sBuilder.Append(t.ToString("x2"));
        }
        return sBuilder.ToString();
    }
}