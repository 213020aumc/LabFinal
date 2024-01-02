using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Q2_Part2.Models;

namespace Q2_Part2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductContext _context;

        public HomeController(ProductContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
              return _context.ProductInfos != null ? 
                          View(await _context.ProductInfos.ToListAsync()) :
                          Problem("Entity set 'ProductContext.ProductInfos'  is null.");
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductInfos == null)
            {
                return NotFound();
            }

            var productInfo = await _context.ProductInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productInfo == null)
            {
                return NotFound();
            }

            return View(productInfo);
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
        public async Task<IActionResult> Create([Bind("Id,ProductName,Catagory,Price,Quantity")] ProductInfo productInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productInfo);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductInfos == null)
            {
                return NotFound();
            }

            var productInfo = await _context.ProductInfos.FindAsync(id);
            if (productInfo == null)
            {
                return NotFound();
            }
            return View(productInfo);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Catagory,Price,Quantity")] ProductInfo productInfo)
        {
            if (id != productInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductInfoExists(productInfo.Id))
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
            return View(productInfo);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductInfos == null)
            {
                return NotFound();
            }

            var productInfo = await _context.ProductInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productInfo == null)
            {
                return NotFound();
            }

            return View(productInfo);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductInfos == null)
            {
                return Problem("Entity set 'ProductContext.ProductInfos'  is null.");
            }
            var productInfo = await _context.ProductInfos.FindAsync(id);
            if (productInfo != null)
            {
                _context.ProductInfos.Remove(productInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductInfoExists(int id)
        {
          return (_context.ProductInfos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
