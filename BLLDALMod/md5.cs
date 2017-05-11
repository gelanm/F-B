using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

public class MD5
{
    public static string Hash(string toHash)
    {
        MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();
        byte[] bytes = Encoding.UTF7.GetBytes(toHash);
        bytes = crypto.ComputeHash(bytes);
        StringBuilder sb = new StringBuilder();
        foreach (byte num in bytes)
        {
            sb.AppendFormat("{0:x2}", num);
        }
        return sb.ToString();
    }
}

