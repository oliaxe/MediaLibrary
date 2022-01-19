using Microsoft.AspNetCore.Mvc;
using Övningsuppgift_2.Data;
using Övningsuppgift_2.Models;
using Övningsuppgift_2.Services;


namespace Övningsuppgift_2.Controllers
{
    public class AlbumsController : Controller
    {
        // GET: BooksController
        private readonly SqlContext _sql;
        private readonly IAlbumsService _albumService;

        public AlbumsController(SqlContext sql, IAlbumsService albumService)
        {
            _sql = sql;
            _albumService = albumService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.Albums = await _albumService.GetAllAsync();
            return View(viewModel.Albums);
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Albums albums)
        {
            _albumService.AddAsync(albums);
            return RedirectToAction("Index");

        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var albumsFromDb = _sql.Albums.Find(id);
            if (albumsFromDb == null)
            {
                return NotFound();
            }
            return View(albumsFromDb);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(Books obj)
        public async Task<IActionResult> Edit(Albums albums)
        {
            _albumService.UpdateAsync(albums);
            return RedirectToAction("Index");
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var albumsFromDb = _sql.Albums.Find(id);
            if (albumsFromDb == null)
            {
                return NotFound();
            }
            return View(albumsFromDb);
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Albums albums)
        {
            _albumService.DeleteAsync(albums);
            return RedirectToAction("Index");
        }
    }
}
