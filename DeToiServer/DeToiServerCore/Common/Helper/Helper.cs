﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

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

        public static IEnumerable<KeyValuePair<string, object>> GetKeyValuePairs(object obj)
        {
            Type type = obj.GetType();

            PropertyInfo[] properties = type.GetProperties();

            // Iterate through properties and get key-value pairs
            foreach (var property in properties)
            {
                // Get the value of the property with null-check
                object value = property.GetValue(obj) ?? DBNull.Value;

                var kvp = new KeyValuePair<string, object>(property.Name, value);
                yield return kvp;
            }
        }
    }
}
