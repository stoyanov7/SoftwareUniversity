namespace MyLibrary.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Models;

    public class BookService : IBookService
    {
        private readonly LibraryContext context;

        public BookService(LibraryContext context)
        {
            this.context = context;
        }

        public void AddBook(Book book)
        {
            this.context.Books.Add(book);
            this.context.SaveChanges();
        }

        public IList<Book> GetBooksList => this.context.Books.ToList();
    }
}