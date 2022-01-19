using Microsoft.AspNetCore.Mvc;
using Övningsuppgift_2.Data;
using Övningsuppgift_2.Models;
using Övningsuppgift_2.Services;


namespace Övningsuppgift_2.Controllers
{
    public class BooksController : Controller
    {
        // GET: BooksController
        private readonly SqlContext _sql;
        private readonly IBookService _bookService;

        public BooksController(SqlContext sql, IBookService bookService)
        {
            _sql = sql;
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.Books = await _bookService.GetAllAsync();
            return View(viewModel.Books);
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Books book)
        {
            _bookService.AddAsync(book);
            return RedirectToAction("Index");
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bookFromDb = _sql.Books.Find(id);
            if (bookFromDb == null)
            {
                return NotFound();
            }
            return View(bookFromDb);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(Books obj)
        public async Task<IActionResult> Edit(Books book)
        {
            _bookService.UpdateAsync(book);
            return RedirectToAction("Index");
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bookFromDb = _sql.Books.Find(id);
            if (bookFromDb == null)
            {
                return NotFound();
            }
            return View(bookFromDb);
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Books book)
        {
            _bookService.DeleteAsync(book);
            return RedirectToAction("Index");
        }
    }
}
