using BooksStore.Website.Data;
using BooksStore.Website.Data.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace BooksStore.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BooksController : Controller
    {
        private readonly BooksDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;

        public BooksController(BooksDbContext db, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _db.Books.ToListAsync(); 
            return View(books);
        }
        public IActionResult Create()
        {
            return View(new Book());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.TagId = 1;
                book.CreatedUserId = new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9");
                _db.Books.Add(book);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var books = await _db.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book  books)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Update(books);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(books);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var books = await _db.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Book books)
        {
            _db.Books.Remove(books);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var books = await _db.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }
        [HttpPost]
        public async Task<JsonResult> ImageUpload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var imagePath = @"\Upload\Images\";
                var uploadPath = _hostingEnvironment.WebRootPath + imagePath;

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + "." + file.FileName.Split(".")[1].ToLower();
                string filePath = Path.Combine(uploadPath, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return Json(uniqueFileName);
            }

            return Json(null);
        }


    }
}
