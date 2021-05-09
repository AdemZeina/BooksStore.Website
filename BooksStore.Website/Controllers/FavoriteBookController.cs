using BooksStore.Website.Data;
using BooksStore.Website.Data.Entity;
using BooksStore.Website.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Website.Controllers
{
    public class FavoriteBookController : Controller
    {
        private readonly BooksDbContext _db;

        public FavoriteBookController(BooksDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.GetLoggedInUserId<string>();
            var list = await _db.Books.Include(x=>x.FavoriteBooks).Include(x=>x.Tag).Where(x => x.FavoriteBooks.Any(x => x.UserId == userId)).ToListAsync();
            
            return View(list);
        }

        [HttpGet]
        public async Task<JsonResult> Like(int bookId1)
        {
            int bookId = (int)bookId1;
            if (bookId == 0)
            {
                return Json(null);
            }
            var userId = User.GetLoggedInUserId<string>();

            var fav = await _db.FavoriteBooks.FirstOrDefaultAsync(x => x.BookId == bookId & x.UserId == userId);
            if (fav != null)//UnLike
            {
                _db.FavoriteBooks.Remove(fav);
                await _db.SaveChangesAsync();
                return Json("Success");
            }
            else //like
            {
                var newLike = new FavoriteBook()
                {
                    UserId = userId,
                    BookId = bookId,
                    CreatedAt = DateTime.UtcNow
                };
                await _db.FavoriteBooks.AddAsync(newLike);
                await _db.SaveChangesAsync();
            }
            return Json("Success");
        }
    }
}
