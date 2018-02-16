namespace StudentSystem
{
    public class Student
    {
        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }

        public double Grade { get; set; }

        public int Age { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{this.Name} is {this.Age} years old. {this.GetGradeComment()}";
        }

        private string GetGradeComment()
        {
            if (this.Grade >= 5.00)
            {
                return "Excellent student.";
            }

            if (this.Grade < 5.00 && this.Grade >= 3.50)
            {
                return "Average student.";
            }

            return "Very nice person.";
        }
    }
}