namespace MyLibrary.Services.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface IBookService
    {
        void AddBook(Book book);

        IList<Book> GetBooksList { get; }

        Book FindBookById(int id);
    }
}