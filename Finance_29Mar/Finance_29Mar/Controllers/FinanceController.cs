using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finance_29Mar.Models;
using Finance_29Mar.Controllers;

namespace Finance_29Mar.Controllers
{
    public class FinanceController : Controller
    {
        FinanceContext fc = new FinanceContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Customer c)
        {
            if(ModelState.IsValid)
            {
                fc.Add(c);
                fc.SaveChanges();
                return View("Display", "Product");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Login()
        {
            return RedirectToAction("Index");
        }
    }
}
