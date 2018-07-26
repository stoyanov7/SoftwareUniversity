namespace PhotoShare.Utilities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string email = value as string;

            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            return email.Contains("@");
        }
    }
}
