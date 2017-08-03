namespace BashSoft
{
    using IO;

    public class StartUp
    {
        /// <summary>
        /// The entry point for the application.
        /// </summary>
        /// <param name="args"> A list of command line arguments.</param>
        public static void Main(string[] args)
        {
            /*
            * IoManager.TraverseDirectory(@"C:\Program Files");
            * StudentsRepository.InitializeData();
            * StudentsRepository.GetAllStudentsFromCourse("Unity");
            * StudentsRepository.GetStudentScoreFromCourese("Unity", "Ivan");
            * Tester.CompareContent(@"C:\Users\Joro\test2.txt", @"C:\Users\Joro\test3.txt");
            */

            IoManager.TraverseDirectory(3);
        }
    }
}