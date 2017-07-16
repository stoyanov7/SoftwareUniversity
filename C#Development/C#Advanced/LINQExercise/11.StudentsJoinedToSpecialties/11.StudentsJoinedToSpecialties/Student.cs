namespace _11.StudentsJoinedToSpecialties
{
    public class Student
    {
        public Student(string studentName, string facultyNumber)
        {
            this.StudentName = studentName;
            this.FacultyNumber = facultyNumber;
        }

        public string StudentName { get; set; }

        public string FacultyNumber { get; set; }
    }
}
