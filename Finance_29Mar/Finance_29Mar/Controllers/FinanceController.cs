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
        db dbobj = new db();

        //private readonly FinanceContext _fcc;
        //public FinanceController(FinanceContext f)
        //{
        //    _fcc = f;

        //}
        public IActionResult Index()
        {
            List<Product> productlist = fc.Products.ToList();
            return View(productlist);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Customer c)
        {
            if (ModelState.IsValid)
            {
                fc.Add(c);
                fc.SaveChanges();
                TempData["msg"] = "User registered succesfully!!!";
                return View("Display", "Product");
            }
            else
            {
                TempData["msg"] = "Couldn't register, Try again!!!";
                return View();
            }
        }
        public IActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Login([Bind] valLogin lg)
        {
            int res = dbobj.LoginCheck(lg);
            if(res==1)
            {
                TempData["msg"] = "You are welcome to Login page!!!";
            }
            else
            {
                TempData["msg"] = "Incorrect details!!";
            }
            return View();
        }
        
    }
}
