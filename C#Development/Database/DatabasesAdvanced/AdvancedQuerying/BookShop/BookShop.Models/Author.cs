namespace BookShop.Models
{
    using System.Collections.Generic;

    public class Author
    {
        public Author() => this.Books = new List<Book>();

        public Author(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Books = new List<Book>();
        }

        public int AuthorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
