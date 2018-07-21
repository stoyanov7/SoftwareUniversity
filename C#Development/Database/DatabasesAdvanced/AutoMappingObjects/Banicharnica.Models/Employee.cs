namespace Banicharnica.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public DateTime? Birtdate { get; set; }

        public string Address { get; set; }
    }
}
