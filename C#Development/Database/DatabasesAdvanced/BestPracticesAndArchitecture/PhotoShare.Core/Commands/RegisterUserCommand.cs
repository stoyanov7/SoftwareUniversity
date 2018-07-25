namespace PhotoShare.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Contracts;

    public class RegisterUserCommand : ICommand
    {
        public RegisterUserCommand()
        {
           
        }

        // RegisterUser <username> <password> <repeat-password> <email>
        public string Execute(string[] data)
        {
            throw new NotImplementedException();
        }

        private bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
