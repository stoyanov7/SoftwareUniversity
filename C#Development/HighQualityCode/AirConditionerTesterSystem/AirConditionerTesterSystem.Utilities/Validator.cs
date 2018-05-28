namespace AirConditionerTesterSystem.Utilities
{
    using System;

    public static class Validator
    {
        public static void CheckProperty(string value, int length, string message)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < length)
            {
                throw new ArgumentException(message);
            }
        }

        public static void CheckNegativeValue(int value, string message)
        {
            if (value <= 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
