using AutoMapper;
using BooksStore.Website.Data;
using BooksStore.Website.Data.Entity;
using BooksStore.Website.Helpers;
using BooksStore.Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BooksDbContext _db;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, BooksDbContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel model = new HomeViewModel();
           
            var userId = User.GetLoggedInUserId<string>();
            model.ScienceBooks = _mapper.Map<List<BookViewModel>>(await _db.Books.Include(x=>x.FavoriteBooks.Where(x=>x.UserId== userId)).Where(x => x.Tag.Name.Equals("Science")).Take(4).ToListAsync());
            model.ProgrammingBooks = _mapper.Map<List<BookViewModel>>(await _db.Books.Include(x => x.FavoriteBooks.Where(x => x.UserId == userId)).Where(x => x.Tag.Name.Equals("Programming")).Take(4).ToListAsync());
            model.TechnologyBooks = _mapper.Map<List<BookViewModel>>(await _db.Books.Include(x => x.FavoriteBooks.Where(x => x.UserId == userId)).Where(x => x.Tag.Name.Equals("Technology")).Take(4).ToListAsync());
            model.HealthBooks = _mapper.Map<List<BookViewModel>>(await _db.Books.Include(x => x.FavoriteBooks.Where(x => x.UserId == userId)).Where(x => x.Tag.Name.Equals("Health")).Take(4).ToListAsync());
            model.TravelBooks = _mapper.Map<List<BookViewModel>>(await _db.Books.Include(x => x.FavoriteBooks.Where(x => x.UserId == userId)).Where(x => x.Tag.Name.Equals("Travel")).Take(4).ToListAsync());

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
