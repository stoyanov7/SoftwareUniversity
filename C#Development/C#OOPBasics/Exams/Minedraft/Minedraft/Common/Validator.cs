namespace Minedraft.Common
{
    using System;

    public static class Validator
    {
        public static void CheckIfNegative(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
        }

        public static void CheckGivenRange(double value, int minRange, int maxRange, string message)
        {
            if (value < minRange || value >= maxRange)
            {
                throw new ArgumentException(message);
            }
        }
    }
}