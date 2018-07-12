namespace P01_StudentSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        public Course()
        {
            this.Resources = new List<Resource>();
            this.StudentsEnrolled = new List<StudentCourse>();
            this.HomeworkSubmissions = new List<Homework>();
        }

        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public ICollection<Resource> Resources { get; set; } 

        public ICollection<StudentCourse> StudentsEnrolled { get; set; } 

        public ICollection<Homework> HomeworkSubmissions { get; set; } 
    }
}