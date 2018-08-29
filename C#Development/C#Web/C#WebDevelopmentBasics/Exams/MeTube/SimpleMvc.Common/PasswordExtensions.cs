namespace SimpleMvc.Common
{
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    public static class PasswordExtensions
    {
        public static string GenerateSHA256String(string inputString)
        {
            var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(inputString);
            var hash = sha256.ComputeHash(bytes);

            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(IEnumerable<byte> hash)
        {
            var result = new StringBuilder();

            foreach (var i in hash)
            {
                result.Append(i.ToString("X2"));
            }

            return result.ToString();
        }
    }
}