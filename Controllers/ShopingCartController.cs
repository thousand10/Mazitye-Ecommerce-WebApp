using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using mazitye.Data;
using mazitye.Models;


namespace  mazitye.Controllers
{
 
    public class ShopingCartController: Controller
    {
        private readonly MazityeDbContext _databaseDbContext;

        public ShopingCartController(MazityeDbContext databaseDbContext)
        {
            _databaseDbContext = databaseDbContext;
        }

        public IActionResult AddingToCart(int productId)
        {
            if(productId == 0){ return NotFound(); }
            var takeTheProductFromTheDatabaseWithSameId = _databaseDbContext.products.FirstOrDefault(a => a.Id == productId);
            if(takeTheProductFromTheDatabaseWithSameId == null){ return NotFound(); }
            Console.WriteLine($"product with this name {takeTheProductFromTheDatabaseWithSameId.Name} is added to cart");
            return RedirectToRoute(nameof(ShopController) + nameof(ShopController.ListOfProducts)); 
        }
    }
}