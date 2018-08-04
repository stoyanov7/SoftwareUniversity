namespace TeamBuilder.Utilities
{
    using System;
    using System.Linq;

    public static class Validator
    {
        public static void CheckLength(int expectedLength, string[] array)
        {
            if (expectedLength != array.Length)
            {
                throw new FormatException(Constants.InvalidArgumentsCount);
            }
        }

        public static void ValidateUsername(string username)
        {
            if (username.Length < Constants.MinUsernameLength ||
                username.Length > Constants.MaxUsernameLength)
            {
                throw new ArgumentException(
                    string.Format(Constants.UsernameNotValid, username));
            }
        }

        public static void ValidatePassword(string password)
        {
            if (password.Length < Constants.MinPasswordLength ||
                password.Length > Constants.MaxPasswordLength ||
                !password.Any(char.IsDigit) ||
                !password.Any(char.IsUpper))
            {
                throw new ArgumentException(
                    string.Format(Constants.PasswordNotValid, password));
            }
        }

        public static void ValidateNames(string name, string message)
        {
            if (name.Length > Constants.MaxFirstNameLength)
            {
                throw new ArgumentException(message);
            }
        }
    }
}