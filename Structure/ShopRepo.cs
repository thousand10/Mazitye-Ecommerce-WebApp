using System;
using System.Collections.Generic;
using mazitye.Data;
using mazitye.Models;


namespace mazitye.Structure
{
    public class ShopRepo : IShop
    {
        private readonly MazityeDbContext _databaseDbContext;

        public ShopRepo(MazityeDbContext databaseDbContext)
        {
            _databaseDbContext = databaseDbContext;
        }


        public IEnumerable<Product> GetAListOfAllProducts()
        {
            var ListOfProducts = _databaseDbContext.products.ToList();
            return ListOfProducts;
        }

        public Product GetASingleProduct(int id)
        {

            Product getProduct =  _databaseDbContext.products.FirstOrDefault(e => e.Id == id);
            if (getProduct == null)
            {
                throw new ArgumentNullException(nameof(getProduct));
            }
            return getProduct;
        
        }

        public void SearchAProduct()
        {
            
        }

    }
}