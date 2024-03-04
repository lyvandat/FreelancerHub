﻿using System.Text;

namespace DeToiServerCore.Common.Helper
{
    public static class Helper
    {
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static string GetDockerConnectionString()
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "detoidb";
            var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "DeToiVN";
            var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD") ?? "Password@12345#";
            return $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};TrustServerCertificate=True;";
        }

        public static bool IsInAcceptableZone(string customerAddress, string freelanceAddress)
        {
            return true;
        }

        public static dynamic? StringToNum(string? value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return value;
        }

        public static string? DynamicToString(dynamic? value)
        {
            return value?.ToString();
        }
    }
}
