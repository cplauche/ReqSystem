using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.IRepos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReqSystem.DAL.Repos;
using ReqSystem.Data;
using ReqSystem.Models;
using ReqSystem.ViewModels;

namespace ReqSystem.Controllers
{
    public class RequisitionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepo<Requisition> _repo;
        private readonly IMapper _mapper;

        public RequisitionsController(
            ApplicationDbContext context,
            IRepo<Requisition> repo,
            IMapper mapper)
        {
            _context = context;
            _repo = repo;
            _mapper = mapper;
        }
        //User View their active reqs
        public IActionResult ViewActiveReqs(string ReqUserId)
        {
            List<Requisition> Reqs = _repo.FindAll().ToList();
            List<Requisition> ActiveReqs = new List<Requisition>();
            foreach (Requisition r in Reqs)
            {
                if(r.ReqUserId.Equals(ReqUserId) && r.Status == 0)
                {
                    ActiveReqs.Add(r);
                }
            }
            return View(ActiveReqs);
        }
        //User cancels an active req
        public IActionResult CancelReq(int RequisitionId)
        {
            foreach(Requisition r in _repo.FindAll())
            {
                if(r.Id == RequisitionId)
                {
                    r.Status = ReqStatus.canceled;
                }
            }
            return View();
        }
        //User views past, closed reqs
        public IActionResult ViewClosedReqs(string ReqUserId)
        {
            List<Requisition> ClosedReqs = new List<Requisition>();
            foreach(Requisition r in _repo.FindAll())
            {
                if(r.ReqUserId.Equals(ReqUserId))
                {
                    if(r.Status == ReqStatus.approved || r.Status == ReqStatus.canceled)
                    {
                        ClosedReqs.Add(r);
                    }
                }
            }
            return View(ClosedReqs);
        }
        //User views all their past and present reqs
        public IActionResult ViewAllReqs(string ReqUserId)
        {
            List<Requisition> AllReqs = new List<Requisition>();
            foreach (Requisition r in _repo.FindAll())
            {
                if (r.ReqUserId.Equals(ReqUserId))
                {
                    AllReqs.Add(r);
                }
            }
            return View(AllReqs);
        }
        //Supervisor approve or deny pending req
        public IActionResult ReviewReq()
        {
            return View();
        }
        //Supervisor views all past reqs from their division
        public IActionResult ViewDivisionReqs()
        {
            return View();
        }
        //Supervisor views all reqs from their division that are pending
        public IActionResult ViewPendingDivisionReqs(string ReqUserId)
        {
            List<Requisition> Pending = new List<Requisition>();
            List<Requisition> Reqs = _repo.FindAll().ToList();
            foreach (Requisition r in Reqs)
            {
                //If req is pending
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
        public IActionResult Index()
        {
            //go through and make use repos
            var Requisitions = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Requisition>, List<RequisitionVM>>(Requisitions);

            return View(model);
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
