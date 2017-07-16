namespace _11.StudentsJoinedToSpecialties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsJoinedToSpecialties
    {
        public static void Main(string[] args)
        {
            var specialties = new List<StudentSpecialty>();
            var line = string.Empty;

            while ((line = Console.ReadLine()) != "Students:")
            {
                var lastIndex = line.LastIndexOf(" ");
                var specialityName = line.Substring(0, lastIndex);
                var facultyNumber = line.Substring(lastIndex + 1);
                var currentSpecialty = new StudentSpecialty(specialityName, facultyNumber);
                specialties.Add(currentSpecialty);
            }

            var students = new List<Student>();

            while ((line = Console.ReadLine()) != "END")
            {
                var firstIndex = line.IndexOf(" ");
                var facultyNumber = line.Substring(0, firstIndex);
                var studentNames = line.Substring(firstIndex + 1);
                var currentStudent = new Student(studentNames, facultyNumber);
                students.Add(currentStudent);
            }

            specialties
                .Join(students, sp => sp.FacultyNumber, st => st.FacultyNumber, (sp, st) => new
            {
                Name = st.StudentName,
                FacNumber = sp.FacultyNumber,
                Spec = sp.SpecialityName
            })
            .OrderBy(res => res.Name)
            .ToList()
            .ForEach(res => Console.WriteLine($"{res.Name} {res.FacNumber} {res.Spec}"));
        }
    }
}
