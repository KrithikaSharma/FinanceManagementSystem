using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finance_29Mar.Models;
using Finance_29Mar.Controllers;
//using System.Web.Mvc;
using Microsoft.AspNetCore.Http;

namespace Finance_29Mar.Controllers
{
    public class FinanceController : Controller
    {
        FinanceContext fc = new FinanceContext();
        db dbobj = new db();

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
                fc.Customers.Add(c);
                //fc.Add(c); 
                fc.SaveChanges();
                TempData["msg"] = "User registered succesfully!!!";
                return RedirectToAction("Login");
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
            //int cardstatus = (from cno in fc.Customers
             //                 join cn in CardStatus );


            int res = dbobj.LoginCheck(lg);
            if (res == 1)
            {
                TempData["msg"] = "You are welcome to Login page!!!";
                return RedirectToAction("Dashboard");
            }
            else
            {
                TempData["msg"] = "Incorrect details!!";
                //return View();
            }
            return View();
        }

        public IActionResult Dashboard()
        {
            FinanceContext f = new FinanceContext();
            List<Product> productlist1 = f.Products.ToList();
            return View(productlist1);
        }

        [Route("Finance/GetProductDetails/{id:int}")]
        public IActionResult GetProductDetails(int id)
        {
            Product pList = (from p in fc.Products
                             where id == p.ProductId
                             select p).FirstOrDefault();

            return View(pList);
        }


        /*
        [HttpPost]
        public IActionResult GetProductDetails(int emi)
        {

        }
        */
    }
}
