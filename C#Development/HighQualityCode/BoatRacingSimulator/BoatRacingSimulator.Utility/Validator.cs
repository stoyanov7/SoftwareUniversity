namespace BoatRacingSimulator.Utility
{
    using System;

    public static class Validator
    {
        /// <summary>
        /// Check if property value is less or equal to zero;
        /// </summary>
        /// <param name="value">Value for checking.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <exception cref="ArgumentException"/>
        public static void ValidatePropertyValue(int value, string propertyName)
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(Constants.IncorrectPropertyValueMessage, propertyName));
            }
        }

        /// <summary>
        /// Check if model length is less or equal to given size.
        /// </summary>
        /// <param name="value">Value for checking.</param>
        /// <param name="minModelLength">Minimal model length.</param>
        /// <exception cref="ArgumentException"/>
        public static void ValidateModelLength(string value, int minModelLength)
        {
            if (value.Length < minModelLength)
            {
                throw new ArgumentException(string.Format(Constants.IncorrectModelLenghtMessage, minModelLength));
            }
        }
    }
}
