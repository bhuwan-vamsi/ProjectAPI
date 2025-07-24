using APIPractice.Data;
using APIPractice.Models.Domain;
using APIPractice.Models.DTO;
using APIPractice.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPractice.Repository
{
    public class ProductRepository : IProductRepository<Product>
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) 
        {
            _db = db;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _db.Products.Include("Category").Where(x=> x.IsActive==true).ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            var product= await _db.Products.Include("Category").FirstOrDefaultAsync(u=> u.Id == id && u.IsActive==true);
            if (product == null)
            {
                throw new KeyNotFoundException("Product Not Found");
            }
            return product;
        }

        public async Task<Product> CreateAsync(Product entity)
        {
            entity.IsActive = true;
            await _db.Products.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task UpdateAsync(Product existingProduct, UpdateProductDto updatedProduct)
        {
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.Units = updatedProduct.Units;
            existingProduct.Quantity = updatedProduct.Quantity;
            existingProduct.Threshold = updatedProduct.Threshold;
            existingProduct.ImageUrl = updatedProduct.ImageUrl;
            existingProduct.Category = updatedProduct.Category;
            _db.Products.Update(existingProduct);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteAsync(Product product)
        {
            product.IsActive = false;
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
        }
    }
}
