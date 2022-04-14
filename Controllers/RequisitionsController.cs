using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReqSystem.DAL.Repos;
using ReqSystem.Data;
using ReqSystem.Models;

namespace ReqSystem.Controllers
{
    public class RequisitionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RequisitionRepo _repo;

        public RequisitionsController(
            ApplicationDbContext context,
            RequisitionRepo repo)
        {
            _context = context;
            _repo = repo;
        }

        public IActionResult GetPendingReqs(string ReqUserId)
        {
            List<Requisition> Pending = new List<Requisition>();
            List<Requisition> Reqs = _repo.FindAll().ToList();
            foreach (Requisition r in Reqs)
            {
                //If req is pending and is of the 
                if (r.Status == 0)
                {
                    foreach(Approval a in r.Approvals)
                    {
                        if(a.ReqUserId.Equals(ReqUserId))
                        {
                            Pending.Add(r);
                        }
                    } 
                }   
            }
            return View(Pending);
        }

        // GET: Requisitions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Requisitions.Include(r => r.Budget).Include(r => r.ReqUser).Include(r => r.Vendor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Requisitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisition = await _context.Requisitions
                .Include(r => r.Budget)
                .Include(r => r.ReqUser)
                .Include(r => r.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requisition == null)
            {
                return NotFound();
            }

            return View(requisition);
        }

        // GET: Requisitions/Create
        public IActionResult Create()
        {
            ViewData["BudgetId"] = new SelectList(_context.Budgets, "Id", "Id");
            ViewData["ReqUserId"] = new SelectList(_context.ReqUsers, "Id", "Id");
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Id");
            return View();
        }

        // POST: Requisitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReqUserId,BudgetId,VendorId,Status,Id,TimeStamp")] Requisition requisition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requisition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BudgetId"] = new SelectList(_context.Budgets, "Id", "Id", requisition.BudgetId);
            ViewData["ReqUserId"] = new SelectList(_context.ReqUsers, "Id", "Id", requisition.ReqUserId);
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Id", requisition.VendorId);
            return View(requisition);
        }

        // GET: Requisitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisition = await _context.Requisitions.FindAsync(id);
            if (requisition == null)
            {
                return NotFound();
            }
            ViewData["BudgetId"] = new SelectList(_context.Budgets, "Id", "Id", requisition.BudgetId);
            ViewData["ReqUserId"] = new SelectList(_context.ReqUsers, "Id", "Id", requisition.ReqUserId);
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Id", requisition.VendorId);
            return View(requisition);
        }

        // POST: Requisitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReqUserId,BudgetId,VendorId,Status,Id,TimeStamp")] Requisition requisition)
        {
            if (id != requisition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requisition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequisitionExists(requisition.Id))
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
            ViewData["BudgetId"] = new SelectList(_context.Budgets, "Id", "Id", requisition.BudgetId);
            ViewData["ReqUserId"] = new SelectList(_context.ReqUsers, "Id", "Id", requisition.ReqUserId);
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Id", requisition.VendorId);
            return View(requisition);
        }

        // GET: Requisitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisition = await _context.Requisitions
                .Include(r => r.Budget)
                .Include(r => r.ReqUser)
                .Include(r => r.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requisition == null)
            {
                return NotFound();
            }

            return View(requisition);
        }

        // POST: Requisitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requisition = await _context.Requisitions.FindAsync(id);
            _context.Requisitions.Remove(requisition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequisitionExists(int id)
        {
            return _context.Requisitions.Any(e => e.Id == id);
        }
    }
}
