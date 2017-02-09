using System;
using System.Collections.Generic;
using System.Linq;

public class BookLibrary
{
    public static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var library = new Library();
        library.Books = new List<Book>();

        for (int i = 0; i < n; i++)
        {
            var currentBook = ReadBook();
            library.Books.Add(currentBook);
        }

        var booksPrice = new Dictionary<string, decimal>();
        GetBooksPrice(library.Books, booksPrice);

        booksPrice = booksPrice
            .OrderByDescending(b => b.Value)
            .ThenBy(b => b.Key)
            .ToDictionary(b => b.Key, x => x.Value);

        foreach (var book in booksPrice)
        {
            Console.WriteLine($"{book.Key} -> {book.Value:f2}");
        }
    }

    private static Book ReadBook()
    {
        var tokens = Console.ReadLine().Split(' ').ToArray();
        var title = tokens[0];
        var author = tokens[1];
        var publisher = tokens[2];
        var releaseDate = tokens[3];
        var isbn = tokens[4];
        var price = decimal.Parse(tokens[5]);

        var book = new Book(title, author, publisher, releaseDate, isbn, price);

        return book;
    }

    private static void GetBooksPrice(List<Book> books, Dictionary<string, decimal> booksPrice)
    {
        foreach (var book in books)
        {
            if (!booksPrice.ContainsKey(book.Author))
            {
                booksPrice.Add(book.Author, 0.0m);
            }

            booksPrice[book.Author] += book.Price;
        }
    }
}