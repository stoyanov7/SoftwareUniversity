namespace _11.StudentsJoinedToSpecialties
{
    public class StudentSpecialty 
    {
        public StudentSpecialty (string studentSpeciality, string facultyNumber)
        {
            this.SpecialityName = studentSpeciality;
            this.FacultyNumber = facultyNumber;
        }

        public string SpecialityName { get; set; }

        public string FacultyNumber { get; set; }
    }
}
