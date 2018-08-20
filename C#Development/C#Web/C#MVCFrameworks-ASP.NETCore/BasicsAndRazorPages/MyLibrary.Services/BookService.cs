namespace MyLibrary.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using ViewModels;

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

        public IList<BookViewModel> GetBooksList()
        {
             return this.context
                 .Books
                 .Select(b => new BookViewModel
                 {
                     Id = b.Id,
                     Title = b.Title,
                     AuthorId = b.AuthorId,
                     Author = b.Author.Name,
                     Status = b.IsBorrowed ? "At home" : "Borrowed"
                 })
                 .ToList(); 
        }

        public Book FindBookById(int id)
        {
            return this.context
                .Books
                .Include(b => b.Author)
                .FirstOrDefault(b => b.Id == id);
        }

        public void DeleteBook(int id)
        {
            var book = this.context
                .Books
                .SingleOrDefault(b => b.Id == id);

            this.context.Books.Remove(book);
            this.context.SaveChanges();
        }

        public bool Exists(int id) => this.context.Books.Any(i => i.Id == id);
    }
}