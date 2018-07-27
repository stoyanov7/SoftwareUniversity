namespace PhotoShare.Utilities.Constants
{
    public static class Message
    {
        public const string SuccessfullyAdded = "{0} {1} was added successfully";
        public const string AlreadyExist = "{0} {1} already exist!";
        public const string NotFound = "{0} {1} not found";

        #region User

        public const string InvalidData = "Invalid data!";

        public const string UsernameAlreadyTaken = "Username {0} is already taken!";

        public const string PasswordNotMath = "Passwords do not match!";

        public const string SuccessfullyRegisteredUsername = "User {0} was registered successfully!";

        public const string SuccessfullyDeletedUser = "User {0} was deleted from the database!";

        public const string PropertyNotSupported = "Property {0} not supported";

        public const string SuccessfullyModifiedUser = "User {0} {1} is {2}.";

        public const string InvalidTown = "Value {0} not valid.\nTown {0} not found!";

        public const string InvalidPassword = "Value {0} not valid.\nInvalid Password";

        #endregion
    }
}