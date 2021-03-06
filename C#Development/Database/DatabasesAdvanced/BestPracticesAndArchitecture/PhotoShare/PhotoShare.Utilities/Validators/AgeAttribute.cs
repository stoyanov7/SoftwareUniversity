﻿namespace PhotoShare.Utilities.Validators
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class AgeAttribute : ValidationAttribute
    {
        private const int MinAge = 0;
        private const int MaxAge = 150;

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var age = int.Parse(value.ToString());

            return age >= MinAge && age <= MaxAge;
        }
    }
}
