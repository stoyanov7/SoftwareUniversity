namespace _05.BookLibrary
{
    public class Book
    {
        public Book(string title, string author, string publisher, string releaseDate, string isbn, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
            this.ReleaseDate = releaseDate;
            this.Isbn = isbn;
            this.Price = price;
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public string ReleaseDate { get; set; }

        public string Isbn { get; set; }

        public decimal Price { get; set; }
    } 
}