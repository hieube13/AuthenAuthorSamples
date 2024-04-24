using BookShop.Data.Entities;
using BookShop.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers
{
    //[Authorize]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var listBook = _bookRepository.GetAllBooks();
            return View(listBook);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book model)
        {
            _bookRepository.AddBook(model);
            return RedirectToAction("Index");
        }

        [Route("book/{id}")]
        public IActionResult Details(int id)
        {
            var book = _bookRepository.GetBookDetails(id);
            return View(book);
        }
    }
}
