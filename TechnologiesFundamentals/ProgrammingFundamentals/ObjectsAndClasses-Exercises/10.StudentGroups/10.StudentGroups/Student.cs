namespace _10.StudentGroups
{
    using System;

    public class Student
    {
        public Student(string name, string email, DateTime date)
        {
            this.Name = name;
            this.Email = email;
            this.RegistrationDate = date;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}