namespace MyLibrary.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Contracts;

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

            return this.View(book);
        }
    }
}