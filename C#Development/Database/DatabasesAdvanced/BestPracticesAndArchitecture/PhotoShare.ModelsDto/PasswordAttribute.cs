﻿namespace PhotoShare.ModelsDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class PasswordAttribute : ValidationAttribute
    {
        private const string SpecialSymbols = "!@#$%^&*()_+<>,.?";
        private readonly int minLength;
        private readonly int maxLength;

        public PasswordAttribute(int minLength, int maxLength)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
        }

        private bool ContainsLowercase { get; set; }

        private bool ContainsUppercase { get; set; }

        private bool ContainsDigit { get; set; }

        private bool ContainsSpecialSymbol { get; set; }

        public override bool IsValid(object value)
        {
            var password = value as string;

            if (password?.Length < this.minLength || 
                password?.Length > this.maxLength)
            {
                return false;
            }

            if (this.ContainsLowercase && 
                !password.Any(char.IsLower))
            {
                return false;
            }

            if (this.ContainsUppercase && 
                !password.Any(char.IsUpper))
            {
                return false;
            }

            if (this.ContainsDigit && 
                !password.Any(char.IsDigit))
            {
                return false;
            }

            if (this.ContainsSpecialSymbol && 
                !password.Any(c => SpecialSymbols.Contains(c)))
            {
                return false;
            }

            return true;
        }
    }
}