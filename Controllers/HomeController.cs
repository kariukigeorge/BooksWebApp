using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WaterMS.Models;
using WaterMS.Data;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;

namespace WaterMS.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private LibraryContext _context;

        public HomeController(LibraryContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }


        public IActionResult Home()
        {
            return View(_context.Books.ToList());
        }

        public IActionResult CreateBook()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateBk(Books book, Users user)
        {
            var usr = _context.Users.Find(user.UsersID);
            book.date_created = DateTime.Now;
            book.created_by = usr.first_name;
            book.status = "Available";

            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Home", "Home", new { area = "" });



        }
        [HttpGet]
        public async Task<IActionResult> EditBook(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(s => s.user)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.BooksID == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        public async Task<IActionResult> BookDetails(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(s => s.user)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.BooksID == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(s => s.user)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.BooksID == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);



        }

        public IActionResult DeleteConfirmed(string? id)
        {
            if (id == null)
            {

            }
            else
            {
                var bookToUpdate = _context.Books.Find(id);
                _context.Remove(bookToUpdate);
                _context.SaveChanges();
            }

            return RedirectToAction("Home", "Home", new { area = "" });
        }

        public IActionResult Update(string? id, Books book)
        {
            var bookToUpdate = _context.Books.Find(id);
            bookToUpdate.name = book.name;
            bookToUpdate.author = book.author;
            bookToUpdate.isbn_number = book.isbn_number;
            bookToUpdate.url = book.url;
            _context.Update(bookToUpdate);
            _context.SaveChanges();

            return RedirectToAction("Home", "Home", new { area = "" });

        }

        public IActionResult Deactivate(string? id)
        {
            var bookToDeactivate = _context.Books.Find(id);
            bookToDeactivate.status = "Deleted";
            _context.Update(bookToDeactivate);
            _context.SaveChanges();

            return RedirectToAction("Home", "Home", new { area = "" });
        }
    }
}
