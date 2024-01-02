using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Q2_Part1.Models;

namespace Q2_Part1.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookDbContext _context;

        public HomeController(BookDbContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
              return _context.BookInfos != null ? 
                          View(await _context.BookInfos.ToListAsync()) :
                          Problem("Entity set 'BookContext.BookInfos'  is null.");
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookInfos == null)
            {
                return NotFound();
            }

            var bookInfo = await _context.BookInfos
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookInfo == null)
            {
                return NotFound();
            }

            return View(bookInfo);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookTitle,BookAuthor,Isbn,PublicationYear")] Books bookInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookInfo);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookInfos == null)
            {
                return NotFound();
            }

            var bookInfo = await _context.BookInfos.FindAsync(id);
            if (bookInfo == null)
            {
                return NotFound();
            }
            return View(bookInfo);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,BookTitle,BookAuthor,Isbn,PublicationYear")] Books bookInfo)
        {
            if (id != bookInfo.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookInfoExists(bookInfo.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookInfo);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookInfos == null)
            {
                return NotFound();
            }

            var bookInfo = await _context.BookInfos
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookInfo == null)
            {
                return NotFound();
            }

            return View(bookInfo);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookInfos == null)
            {
                return Problem("Entity set 'BookContext.BookInfos'  is null.");
            }
            var bookInfo = await _context.BookInfos.FindAsync(id);
            if (bookInfo != null)
            {
                _context.BookInfos.Remove(bookInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookInfoExists(int id)
        {
          return (_context.BookInfos?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
