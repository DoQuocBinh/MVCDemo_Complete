using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCDemo_Complete.Models;

namespace MVCDemo_Complete.Controllers
{
    public class ProductCController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Upload(IFormFile postedFile, Product product)
        {
            var fileName = Path.GetFileNameWithoutExtension(postedFile.FileName);
            var extension = Path.GetExtension(postedFile.FileName);
            using (var dataStream = new MemoryStream())
            {
                await postedFile.CopyToAsync(dataStream);
                product.Picture = dataStream.ToArray();
            }
            ProductDB2Context db = new ProductDB2Context();
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
            
        }
    }
}
