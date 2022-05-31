using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using mazitye.Structure;
using mazitye.Models;
using mazitye.Data;

namespace  mazitye.Controllers
{
 
    public class AdminController: Controller
    {
        private readonly IAdmin _adminRepoContext;
        private readonly MazityeDbContext _databaseDbContext;

        public AdminController(IAdmin adminRepoContext, MazityeDbContext databaseDbContext)
        {
            _adminRepoContext = adminRepoContext;
            _databaseDbContext = databaseDbContext;
        }

        public IActionResult AdminPanel()
        {
            IEnumerable<Product> ListOfAvailableProducts  = _adminRepoContext.GetAllTheProducts();
            return View(ListOfAvailableProducts);
        }


        public IActionResult CreateProduct()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(Product dataProductFromTheForm)
        {
            if(ModelState.IsValid)
            {
                _adminRepoContext.CreateANewProduct(dataProductFromTheForm);
                return RedirectToAction("AdminPanel");
            }
            return View(dataProductFromTheForm);
        }


        public IActionResult ViewSingleProduct(int id)
        {
            if(id == 0)
            {
                return NotFound(nameof(id));
            }
            Product SingleProduct = _adminRepoContext.GetASingleProductById(id);
            if(SingleProduct == null) 
            {
                return NotFound(nameof(SingleProduct));
            }
            return View(SingleProduct);
        }

        [HttpGet]
        public IActionResult UpdateSingleProduct(int id)
        {
            if (id == 0) { return NotFound(); }
            Product product = _adminRepoContext.GetASingleProductById(id);
            if(product == null) {  return NotFound(); }
            return View(product);
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSingleProduct(Product dataInputFromTheForm)
        {
            if(ModelState.IsValid)
            {
                Console.WriteLine("data is valid");
                _adminRepoContext.UpdateAProduct(dataInputFromTheForm);
                return RedirectToAction("AdminPanel");
            }
            return View(dataInputFromTheForm);
    
        } 


         
        public IActionResult DeleteAProduct(int? id)
        {
            if(id == 0 && id == null)
            {
                return NotFound();
            }
            var productToDelete = _databaseDbContext.products.FirstOrDefault(a => a.Id == id);
            if (productToDelete != null)
            {
                _databaseDbContext.products.Remove(productToDelete);
                _databaseDbContext.SaveChanges();
                return RedirectToAction("AdminPanel");
            }
            return RedirectToAction("AdminPanel");

        }

    }
}