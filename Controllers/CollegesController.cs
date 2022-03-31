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
    public class CollegesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CollegesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Colleges
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Colleges.Include(c => c.Address).Include(c => c.Budget).Include(c => c.Semester);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Colleges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var college = await _context.Colleges
                .Include(c => c.Address)
                .Include(c => c.Budget)
                .Include(c => c.Semester)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (college == null)
            {
                return NotFound();
            }

            return View(college);
        }

        // GET: Colleges/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Id");
            ViewData["BudgetId"] = new SelectList(_context.Budgets, "Id", "Id");
            ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Id");
            return View();
        }

        // POST: Colleges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,AddressId,SemesterId,BudgetId,Id,TimeStamp")] College college)
        {
            if (ModelState.IsValid)
            {
                _context.Add(college);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Id", college.AddressId);
            ViewData["BudgetId"] = new SelectList(_context.Budgets, "Id", "Id", college.BudgetId);
            ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Id", college.SemesterId);
            return View(college);
        }

        // GET: Colleges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var college = await _context.Colleges.FindAsync(id);
            if (college == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Id", college.AddressId);
            ViewData["BudgetId"] = new SelectList(_context.Budgets, "Id", "Id", college.BudgetId);
            ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Id", college.SemesterId);
            return View(college);
        }

        // POST: Colleges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,AddressId,SemesterId,BudgetId,Id,TimeStamp")] College college)
        {
            if (id != college.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(college);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollegeExists(college.Id))
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
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Id", college.AddressId);
            ViewData["BudgetId"] = new SelectList(_context.Budgets, "Id", "Id", college.BudgetId);
            ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Id", college.SemesterId);
            return View(college);
        }

        // GET: Colleges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var college = await _context.Colleges
                .Include(c => c.Address)
                .Include(c => c.Budget)
                .Include(c => c.Semester)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (college == null)
            {
                return NotFound();
            }

            return View(college);
        }

        // POST: Colleges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var college = await _context.Colleges.FindAsync(id);
            _context.Colleges.Remove(college);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollegeExists(int id)
        {
            return _context.Colleges.Any(e => e.Id == id);
        }
    }
}
