namespace MyLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Book
    {
        public Book()
        {
            this.Borrowerses = new List<BookBorrowers>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        public string Description { get; set; }

        [ForeignKey("Id")]
        public int AuthorId { get; set; }
        [Required]
        public Author Author { get; set; }

        public string ImageUrl { get; set; }

        public bool IsBorrowed { get; set; }

        public ICollection<BookBorrowers> Borrowerses { get; set; }
    }
}
