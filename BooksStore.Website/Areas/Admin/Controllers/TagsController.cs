using BooksStore.Website.Data;
using BooksStore.Website.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using  OpenTracing.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Website.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Administrator")]
    public class TagsController : BaseController
    {
        private readonly BooksDbContext _db;

        public TagsController(BooksDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tags = await _db.Tags.ToListAsync();
            return View(tags);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new Tag());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tag Tags)
        {
            if (ModelState.IsValid)
            {
                _db.Tags.Add(Tags);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Tags);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tags = await _db.Tags.FindAsync(id);
            if (tags == null)
            {
                return NotFound();
            }
            return View(tags);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Tag Tags)
        {
            if (ModelState.IsValid)
            {

                _db.Tags.Update(Tags);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Tags);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tags = await _db.Tags.FindAsync(id);
            if (tags == null)
            {
                return NotFound();
            }
            return View(tags);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Tag Tags)
        {
            _db.Tags.Remove(Tags);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tags = await _db.Tags.FindAsync(id);
            if (tags == null)
            {
                return NotFound();
            }
            return View(tags);

        }


    }
}