namespace BashSoft.Exceptions
{
    public static class ExceptionMessages
    {
        public const string DataAlreadyInitialisedException = "Data is already initialized!";

        public const string DataNotInitializedExceptionMessage = "The data structure must be initialised first in order to make any operations with it.";

        public const string InexistingCourseInDataBase = "The course you are trying to get does not exist in the data base!";

        public const string InexistingStudentInDataBase = "The user name for the student you are trying to get does not exist!";

        public const string InvalidPath = "The name of the directory is not valid!";

        public const string ComparisonOfFilesWithDifferentSizes = "Files not of equal size, certain mismatch.";
    }
}
