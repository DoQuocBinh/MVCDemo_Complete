using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCDemo_Complete.Models;

namespace MVCDemo_Complete.Controllers
{
    public class ProductCController : Controller
    {
        ProductDB2Context db = new ProductDB2Context();

        public IActionResult Search(string txtSearch)
        {
            var result = db.Products.Where(p => p.ProductName.Contains(txtSearch)).
                    Include(p => p.Category).ToList();
            return View("Index", result);
        }
        public IActionResult Index()
        {
            
            //load both Product and Category
            return View(db.Products.Include(p=>p.Category).ToList());
        }
        public IActionResult Create()
        {
            var Categories = db.Categories.ToList();
            ViewBag.Categories = Categories;
            return View();
        }
        public async Task<IActionResult> Upload(IFormFile postedFile, Product product)
        {
            //var fileName = Path.GetFileNameWithoutExtension(postedFile.FileName);
            //var extension = Path.GetExtension(postedFile.FileName);
            using (var dataStream = new MemoryStream())
            {
                await postedFile.CopyToAsync(dataStream);
                product.Picture = dataStream.ToArray();
            }
           
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}
