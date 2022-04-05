using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finance_29Mar.Models;

namespace Finance_29Mar.Controllers
{
    public class ProductController : Controller
    {
        FinanceContext fc = new FinanceContext();
        public IActionResult Index()
        {
            return View();
        }
        /*
        public IActionResult Display()
        {
            List<Product> productlist = fc.Products.ToList();
            return View(productlist);
        }
        */
    }
}
