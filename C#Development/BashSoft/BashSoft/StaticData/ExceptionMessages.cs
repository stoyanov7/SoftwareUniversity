namespace BashSoft.StaticData
{
    /// <summary>
    /// Set of error messages to display.
    /// </summary>
    public static class ExceptionMessages
    {
        public const string DataAlreadyInitialisedException = "Data is already initialized!";

        public const string DataNotInitializedExceptionMessage = "The data structure must be initialised first in order to make any operations with it.";

        public const string InexistingStudentInDataBase = "The user name for the student you are trying to get does not exist!";

        public const string InvalidFiles = "Files are identical. There are no mismatches.";

        public const string UnauthorizedAccess = "The folder/file you are trying to get access needs a higher level of rights than you currently have.";

        public const string InvalidNameLength = "Name must be with minimum length 1!";

        public const string InvalidPath = "The folder/file you are trying to access at the current address, does not exist.";

        public const string ComparisonOfFilesWithDifferentSizes = "Files not of equal size, certain mismatch.";

        public const string ForbiddenSymbolsContainedInName = "The given name contains symbols that are not allowed to be used in names of files and folders.";
    }
}