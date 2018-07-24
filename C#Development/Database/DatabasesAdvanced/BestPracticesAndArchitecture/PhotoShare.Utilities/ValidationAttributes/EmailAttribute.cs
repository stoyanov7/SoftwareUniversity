namespace PhotoShare.Utilities.ValidationAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var email = value as string;
            var result = !string.IsNullOrEmpty(email) && email.Contains("@");

            return result;
        }
    }
}