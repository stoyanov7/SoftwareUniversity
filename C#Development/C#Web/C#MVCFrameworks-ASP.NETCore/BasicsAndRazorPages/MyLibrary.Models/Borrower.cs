namespace MyLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Borrower
    {
        public Borrower()
        {
            this.BorrowersedBooks = new List<BookBorrowers>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<BookBorrowers> BorrowersedBooks { get; set; }
    }
}