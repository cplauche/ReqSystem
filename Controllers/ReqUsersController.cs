using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Controllers
{
    public class ReqUsersController : Controller
    {
        //purchasing department only
        public IActionResult ConfigureEmployeeRoles()
        {
            return View();
        }
        // GET: ReqUsersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReqUsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReqUsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReqUsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReqUsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReqUsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReqUsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReqUsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
