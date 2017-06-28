namespace _02.JSONStringify
{
    using System.Collections.Generic;

    public class Student
    {
        public Student(string name, int age, List<int> grades)
        {
            this.Name = name;
            this.Age = age;
            this.Grades = grades;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public List<int> Grades { get; set; }

        public override string ToString()
        {
            return $"{{name:\"{this.Name}\",age:{this.Age},grades:[{string.Join(", ", this.Grades)}]}}";
        }
    }
}
