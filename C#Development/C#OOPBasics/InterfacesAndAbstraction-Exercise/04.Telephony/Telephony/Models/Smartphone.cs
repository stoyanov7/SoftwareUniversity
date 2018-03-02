namespace Telephony.Models
{
    using System.Linq;
    using Contracts;

    public class Smartphone : ICaller, IBrowser
    {
        public string Call(string phoneNumber) => IsNumberValid(phoneNumber)
            ? $"Calling... {phoneNumber}"
            : "Invalid number!";

        public string Browse(string url) => IsUrlValid(url) ? $"Browsing: {url}!" : "Invalid URL!";

        private static bool IsUrlValid(string url) => url.All(t => !char.IsDigit(t));

        private static bool IsNumberValid(string phoneNumber) => phoneNumber.All(char.IsDigit);
    }
}