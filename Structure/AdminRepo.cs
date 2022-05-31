using System;
using System.Collections.Generic;
using mazitye.Data;
using mazitye.Models;


namespace mazitye.Structure
{
    public class AdminRepo : IAdmin
    {
        private readonly MazityeDbContext _databaseContext;

        public AdminRepo(MazityeDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        public void CreateANewProduct(Product dataToCreateProduct)
        {
            _databaseContext.products.Add(dataToCreateProduct);
            _databaseContext.SaveChanges();
        }


        public void DeleteAProduct(int dataToDeleteAProduct)
        {
            var dataToDelete = _databaseContext.products.FirstOrDefault(a => a.Id == dataToDeleteAProduct);
            _databaseContext.products.Remove(dataToDelete); 
            _databaseContext.SaveChanges();
        }


        public IEnumerable<Product> GetAllTheProducts()
        {
            return _databaseContext.products.ToList();
        }


        public Product GetASingleProductById(int id)
        {
            var SingleProduct = _databaseContext.products.FirstOrDefault(e => e.Id == id);
            return SingleProduct;
        }


        public void UpdateAProduct(Product dataToUpdateAProduct)
        {
            _databaseContext.products.Update(dataToUpdateAProduct);
            _databaseContext.SaveChanges();
        }
    }
}