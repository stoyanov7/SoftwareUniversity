namespace MyLibrary.Services.Contracts
{
    using System.Collections.Generic;
    using Models;
    using ViewModels;

    public interface IBookService
    {
        void AddBook(Book book);

        IList<BookViewModel> GetBooksList();

        Book FindBookById(int id);
    }
}