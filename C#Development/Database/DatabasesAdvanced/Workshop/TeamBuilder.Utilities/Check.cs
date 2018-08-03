namespace TeamBuilder.Utilities
{
    using System;

    public static class Check
    {
        public static void CheckLength(int expectedLength, string[] array)
        {
            if (expectedLength != array.Length)
            {
                throw new FormatException(ErrorMessages.InvalidArgumentsCount);
            }
        }
    }
}