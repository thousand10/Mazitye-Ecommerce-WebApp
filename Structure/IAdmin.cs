using System;
using System.Collections.Generic;
using mazitye.Models;


namespace mazitye.Structure
{
    public interface IAdmin
    {
        IEnumerable<Product> GetAllTheProducts();
        Product GetASingleProductById(int id);
        void CreateANewProduct(Product dataToCreateProduct);
        void DeleteAProduct(int dataToDeleteAProduct);
        void UpdateAProduct(Product dataToUpdateAProduct);
    }
}