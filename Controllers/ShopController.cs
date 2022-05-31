using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using mazitye.Structure;
using mazitye.Models;
using mazitye.Data;



namespace  mazitye.Controllers
{
 
    public class ShopController: Controller
    {
        private readonly IShop _shopRepoInterface;
        private readonly MazityeDbContext _mazityeDatabaseContext;

        public ShopController(IShop shopRepoInterface, MazityeDbContext mazityeDatabaseContext)
        {
            _shopRepoInterface = shopRepoInterface;
            _mazityeDatabaseContext = mazityeDatabaseContext;
        }


        public IActionResult ListOfProducts()
        {
            IEnumerable<Product> allProducts = _shopRepoInterface.GetAListOfAllProducts();
            return View(allProducts);
        }


        public IActionResult ProductDetails(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            var findingSingleProduct = _shopRepoInterface.GetASingleProduct(id);
            if(findingSingleProduct == null)
            {
                return NotFound(nameof(findingSingleProduct));
            }
            return View(findingSingleProduct);
        }


        public IActionResult Search()
        {
            return View();
        }

    }
}