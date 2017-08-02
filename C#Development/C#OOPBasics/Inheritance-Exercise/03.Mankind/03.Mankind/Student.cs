namespace _03.Mankind
{
    using System;
    using System.Linq;
    using System.Text;

    public class Student : Human
    {
        private const int MinValue = 5;
        private const int MaxValue = 10;

        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get => this.facultyNumber;

            private set
            {
                if (value.Length < MinValue || value.Length > MaxValue ||
                    !value.ToCharArray().All(x => char.IsDigit(x) || char.IsLetter(x)))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.FirstName}");
            sb.AppendLine($"Last Name: {this.LastName}");
            sb.AppendLine($"Faculty number: {this.FacultyNumber}");

            return sb.ToString();
        }
    }
}