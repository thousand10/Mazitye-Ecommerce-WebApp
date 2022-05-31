using System;
using System.Collections.Generic;
using mazitye.Models;

namespace mazitye.Structure
{
    public interface IShop
    {
        void SearchAProduct();
        IEnumerable<Product> GetAListOfAllProducts();
        Product GetASingleProduct(int id);
    }
}