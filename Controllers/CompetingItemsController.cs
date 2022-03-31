using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReqSystem.Data;
using ReqSystem.Models;

namespace ReqSystem.Controllers
{
    public class CompetingItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompetingItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompetingItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CompetingItem.Include(c => c.Item);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CompetingItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competingItem = await _context.CompetingItem
                .Include(c => c.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (competingItem == null)
            {
                return NotFound();
            }

            return View(competingItem);
        }

        // GET: CompetingItems/Create
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Discriminator");
            return View();
        }

        // POST: CompetingItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,Name,ItemNumber,Description,Price,NumberInStock,Id,TimeStamp")] CompetingItem competingItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competingItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Discriminator", competingItem.ItemId);
            return View(competingItem);
        }

        // GET: CompetingItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competingItem = await _context.CompetingItem.FindAsync(id);
            if (competingItem == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Discriminator", competingItem.ItemId);
            return View(competingItem);
        }

        // POST: CompetingItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,Name,ItemNumber,Description,Price,NumberInStock,Id,TimeStamp")] CompetingItem competingItem)
        {
            if (id != competingItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competingItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetingItemExists(competingItem.Id))
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
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Discriminator", competingItem.ItemId);
            return View(competingItem);
        }

        // GET: CompetingItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competingItem = await _context.CompetingItem
                .Include(c => c.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (competingItem == null)
            {
                return NotFound();
            }

            return View(competingItem);
        }

        // POST: CompetingItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competingItem = await _context.CompetingItem.FindAsync(id);
            _context.CompetingItem.Remove(competingItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetingItemExists(int id)
        {
            return _context.CompetingItem.Any(e => e.Id == id);
        }
    }
}
