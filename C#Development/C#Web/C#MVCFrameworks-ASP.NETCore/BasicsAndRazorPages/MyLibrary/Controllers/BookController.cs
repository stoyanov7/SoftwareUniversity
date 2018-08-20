namespace MyLibrary.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Contracts;
    using ViewModels;

    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public IActionResult Add() => this.View();

        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (this.ModelState.IsValid)
            {
                this.bookService.AddBook(book);
                return this.RedirectToAction("Details", "Book", new { id = book.Id });
            }

            return this.View();
        }

        public IActionResult Details(int id)
        {
            var book = this.bookService.FindBookById(id);
            
            if (book == null)
            {
                return this.NotFound();
            }

            var bookDetails = new BookDetailsViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author.Name,
                Description = book.Description,
                ImageUrl = book.ImageUrl,
                Status = book.IsBorrowed ? "At home" : "Borrowed"
            };

            return this.View(bookDetails);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (!this.bookService.Exists(id))
            {
                return this.RedirectToAction("Index", "Home");
            }

            this.bookService.DeleteBook(id);

            return this.RedirectToAction("Index", "Home");
        }
    }
}