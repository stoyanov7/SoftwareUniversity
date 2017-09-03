namespace _06.BookLibraryModification
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class BookLibraryModification
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var library = new Library();
            library.Books = new List<Book>();

            for (var i = 0; i < n; i++)
            {
                var currentBook = ReadBook();
                library.Books.Add(currentBook);
            }

            var date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            library.Books = library.Books
                .Where(x => x.ReleaseDate > date)
                .OrderBy(x => x.ReleaseDate)
                .ThenBy(x => x.Title)
                .ToList();

            foreach (var book in library.Books)
            {
                Console.WriteLine($"{book.Title} -> {book.ReleaseDate:dd.MM.yyyy}");
            }
        }

        private static Book ReadBook()
        {
            var tokens = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var title = tokens[0];
            var author = tokens[1];
            var publisher = tokens[2];
            var releaseDate = DateTime.ParseExact(tokens[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var isbn = tokens[4];
            var price = decimal.Parse(tokens[5]);

            var book = new Book(title, author, publisher, releaseDate, isbn, price);

            return book;
        }
    }
}