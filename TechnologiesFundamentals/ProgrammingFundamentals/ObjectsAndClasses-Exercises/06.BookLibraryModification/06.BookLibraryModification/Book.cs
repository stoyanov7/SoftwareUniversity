namespace _06.BookLibraryModification
{
    using System;

    public class Book
    {
        public Book()
        {
        }

        public Book(string title, string author, string publisher, DateTime releaseDate, string isbn, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
            this.ReleaseDate = releaseDate;
            this.ISBN = isbn;
            this.Price = price;
        }

        public string Title { get; }

        public string Author { get; }

        public string Publisher { get; }

        public DateTime ReleaseDate { get; }

        public string ISBN { get; }

        public decimal Price { get; }
    }
}