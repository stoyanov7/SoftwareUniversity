namespace PhotoShare.Utilities.Validators
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class TagAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            const string pattern = "#[a-zA-Z0-9]{2,20}";
            var regex = new Regex(pattern);

            return regex.IsMatch(value.ToString());
        }
    }
}
