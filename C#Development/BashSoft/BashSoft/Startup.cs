namespace BashSoft
{
    using BashSoft.IO;
    using BashSoft.Repositories;

    public class Startup
    {
        public static void Main(string[] args)
        {
            OutputWriter.PrintLogo();
            //IOManager.TraverseDirectory(@"some path");
            //StudentsRepository.InitializeData();
            //StudentsRepository.GetAllStudentFromCourse("Unity");
            //StudentsRepository.GetStudentFromCourse("Unity", "Ivan");
        }
    }
}
