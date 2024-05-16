using DeToiServerCore.Common.Constants;
using System;
using System.Formats.Asn1;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace DeToiServerCore.Common.Helper
{
    public class Coordination
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    public class DistanceComparingDto
    {
        public IEnumerable<Coordination>? Coordinations { get; set; }
        public Coordination? FreelanceAddress { get; set; }
        public string? AddressOptions { get; set; }
        public int DefaultDistance { get; set; } = 5;
    }

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

        public static string GetMessageQueueConnectionString()
        {
            return Environment.GetEnvironmentVariable("MQ_HOST") ?? "localhost";
        }

        public static string GetRealtimeConnectionString()
        {
            return Environment.GetEnvironmentVariable("MQ_HOST") != null
                ? "http://detoiserver:8080/chat-hub"
                : "https://localhost:7140/chat-hub";
        }

        public static int GetDockerDelayPeriod()
        {
            var timeString = Environment.GetEnvironmentVariable("DELAY_TIME_MS");
            var canParse = int.TryParse(timeString, out int time);

            return canParse ? time : GlobalConstant.DefaultDelayTime;
        }

        public static bool IsInAcceptableZone(Coordination customerAddress, Coordination freelanceAddress, int defaultDistance = 5)
        {
            return !(GeoCalculator.CalculateDistance(customerAddress, freelanceAddress) > defaultDistance); // (km)
        }

        public static bool IsInAcceptableZoneTest(DistanceComparingDto dto)
        {
            if (dto.AddressOptions == null)
            {
                return true;
            }
            if (dto.AddressOptions.Equals(GlobalConstant.AddressOption.None))
            {
                return true;
            }
            if (dto.AddressOptions.Equals(GlobalConstant.AddressOption.Destination))
            {
                var dest = dto.Coordinations?.ElementAt((int)GlobalConstant.AddressOption.DestinationEnum.Place);
                if (dest == null || dto.FreelanceAddress == null) {
                    return false;
                }
                return !(GeoCalculator.CalculateDistance(dest, dto.FreelanceAddress) > dto.DefaultDistance);
            }
            if (dto.AddressOptions.Equals(GlobalConstant.AddressOption.Shipping))
            {

            }

             return true; // (km)
        }

        public static dynamic? StringToNum(string? value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return value;
        }

        public static string? GetLocationUnit(string address, int pos = 0)
        {
            var element = address.Split(',').Reverse().ElementAtOrDefault(pos);
            return element?.Trim();
        }

        public static double CalcRevenueGrowth(double last, double curr)
        {
            if (curr - last == 0) return 0;
            if (last == 0) return curr / 1000;
            return ((curr - last) / last) * 100;
        }

        private static readonly Dictionary<string, string> patterns = new() {
            { "[àáảãạăắằẵặẳâầấậẫẩ]", "a" },
            { "[đ]", "d" },
            { "[èéẻẽẹêềếểễệ]", "e" },
            { "[ìíỉĩị]", "i" },
            { "[òóỏõọôồốổỗộơờớởỡợ]", "o" },
            { "[ùúủũụưừứửữự]", "u" },
            { "[ỳýỷỹỵ]", "y" }
        };

        public static string VieToEngName(string input)
        {
            foreach (var item in patterns)
            {
                input = Regex.Replace(input, item.Key, item.Value);
                input = Regex.Replace(input, item.Key.ToUpper(), item.Value.ToUpper());
            }

            return input;
        }

        public static bool CompareKey(this string _this, string cpmr)
        {
            return _this.Contains(cpmr, StringComparison.CurrentCultureIgnoreCase);
        }

        public static long ToTimeNumber(DateTime input)
        {
            return (long)(input - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }

        public static string RequirementLabelToKey(string label)
        {
            return VieToEngName(label).Replace(' ', '_');
        }

        public static string GetServiceClassName(string className)
        {
            if (string.IsNullOrEmpty(className)) return string.Empty;
            return char.ToLowerInvariant(className[0]) + className[1..];
        }

        public class AesEncryption
        {
            private static readonly string Key = Environment.GetEnvironmentVariable("ENCRYPTION_KEY") 
                ?? "DayLaSuperSecretKeySuDungTrongViecEncryptData";

            private static readonly string IV = Environment.GetEnvironmentVariable("ENCRYPTION_IV")
                ?? "46cd742eb4cbe8f6db524248fa47b40a";

            private static byte[] GetValidKey()
            {
                return SHA256.HashData(Encoding.UTF8.GetBytes(Key));
            }

            // TODO: examine bug propagation
            public static string? Encrypt(string? plainText)
            {
                if (plainText == null) return null;

                using Aes aesAlg = Aes.Create();
                aesAlg.Key = GetValidKey();
                aesAlg.IV = Helper.StringToByteArray(IV);
                aesAlg.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using MemoryStream msEncrypt = new();
                using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using StreamWriter swEncrypt = new(csEncrypt);
                    swEncrypt.Write(plainText);
                }
                return Convert.ToBase64String(msEncrypt.ToArray());
            }

            public static string? Decrypt(string? cipherText)
            {
                if (cipherText == null) return null;

                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using Aes aesAlg = Aes.Create();
                aesAlg.Key = GetValidKey();
                aesAlg.IV = StringToByteArray(IV);
                aesAlg.Mode = CipherMode.CBC;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using MemoryStream msDecrypt = new(cipherBytes);
                using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader srDecrypt = new(csDecrypt);
                return srDecrypt.ReadToEnd();
            }

            public static string GenerateRandomIV()
            {
                byte[] iv = new byte[16]; // IV size for AES is typically 16 bytes
                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(iv);
                }
                return ByteArrayToString(iv);
            }
        }

        public static class GeoCalculator
        {
            private const double EarthRadiusKm = 6371.0;

            public static double CalculateDistance(Coordination from, Coordination to, int calUnit = GlobalConstant.InKilometers)
            {
                var dLat = ToRadians(to.Lat - from.Lat);
                var dLon = ToRadians(to.Lon - from.Lon);

                var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                        Math.Cos(ToRadians(to.Lat)) * Math.Cos(ToRadians(from.Lat)) *
                        Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

                var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

                var distance = EarthRadiusKm * c * calUnit;
                return distance; // (km)
            }

            private static double ToRadians(double angle)
            {
                return Math.PI * angle / 180.0;
            }
        }

        public static bool IsDateOfMonthAndYear(DateTime dateToCheck, int targetMonth, int targetYear)
        {
            return dateToCheck.Month == targetMonth && dateToCheck.Year == targetYear;
        }
    }
}
