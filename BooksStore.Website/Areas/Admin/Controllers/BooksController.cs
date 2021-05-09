using BooksStore.Website.Areas.Admin.Models;
using BooksStore.Website.Data;
using BooksStore.Website.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;


namespace BooksStore.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class BooksController : BaseController
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
            var books = await _db.Books.Include(x=>x.Tag).ToListAsync(); 
            return View(books);
        }
        public async Task<IActionResult> Create()
        {
            var tags = await _db.Tags.ToListAsync();
            
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var tag in tags)
            {
                list.Add(new SelectListItem()
                {
                    Text = tag.Name.ToString(),
                    Value = tag.Id.ToString()
                });
            }
            var tagList = new SelectList(list, "Value", "Text");
            return View(new CreateBookViewModel() { Tags = tagList }); ;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
               
                book.CreatedUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9";
                book.CreatedAt = DateTime.UtcNow;
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
            var book = await _db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            var tags = await _db.Tags.ToListAsync();

            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var tag in tags)
            {
                list.Add(new SelectListItem()
                {
                    Text = tag.Name.ToString(),
                    Value = tag.Id.ToString()
                });
            }
            var tagList = new SelectList(list, "Value", "Text");
            return View(new CreateBookViewModel() { Tags = tagList,Book= book });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book  book)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Update(book);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
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

        public static System.Drawing.Image ScaleImage(System.Drawing.Image image, int height)
        {
            double ratio = (double)height / image.Height;
            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            image.Dispose();
            return newImage;
        }


    }
}
