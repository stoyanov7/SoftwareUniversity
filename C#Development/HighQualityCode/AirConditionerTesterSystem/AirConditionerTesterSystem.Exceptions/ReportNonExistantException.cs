namespace AirConditionerTesterSystem.Exceptions
{
    using System;

    public class ReportNonExistantException : Exception
    {
        public ReportNonExistantException(string message)
            : base(message)
        {
        }
    }
}