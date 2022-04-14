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
    public class StateContractsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StateContractsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StateContracts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StateContracts.Include(s => s.Item);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StateContracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stateContract = await _context.StateContracts
                .Include(s => s.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stateContract == null)
            {
                return NotFound();
            }

            return View(stateContract);
        }

        // GET: StateContracts/Create
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Discriminator");
            return View();
        }

        // POST: StateContracts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,PricePerUnit,ItemId,Id,TimeStamp")] StateContract stateContract)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stateContract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Discriminator", stateContract.ItemId);
            return View(stateContract);
        }

        // GET: StateContracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stateContract = await _context.StateContracts.FindAsync(id);
            if (stateContract == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Discriminator", stateContract.ItemId);
            return View(stateContract);
        }

        // POST: StateContracts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,PricePerUnit,ItemId,Id,TimeStamp")] StateContract stateContract)
        {
            if (id != stateContract.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stateContract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StateContractExists(stateContract.Id))
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
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Discriminator", stateContract.ItemId);
            return View(stateContract);
        }

        // GET: StateContracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stateContract = await _context.StateContracts
                .Include(s => s.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stateContract == null)
            {
                return NotFound();
            }

            return View(stateContract);
        }

        // POST: StateContracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stateContract = await _context.StateContracts.FindAsync(id);
            _context.StateContracts.Remove(stateContract);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StateContractExists(int id)
        {
            return _context.StateContracts.Any(e => e.Id == id);
        }
    }
}
