using APIPractice.Data;
using APIPractice.Model.Domain;
using APIPractice.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPractice.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) 
        {
            _db = db;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _db.Products.Where(x=> x.Is_Active==true).ToListAsync();
        }

        public async Task<Product?> GetAsync(int id)
        {
            var product= await _db.Products.FirstOrDefaultAsync(u=> u.Id == id && u.Is_Active==true);
            if (product == null) 
            {
                return null;
            }
            return product;
        }

        public async Task<Product> CreateAsync(Product entity)
        {
            entity.Is_Active = true;
            await _db.Products.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<Product> UpdateAsync(int id, Product entity)
        {
            var product = await GetAsync(id);
            if(product == null)
            {
                return null;
            }
            product.Name = entity.Name;
            product.Price = entity.Price;
            product.Units = entity.Units;
            product.Quantity = entity.Quantity;
            product.Threshold = entity.Threshold;
            product.Image_url = entity.Image_url;
            //CategoryId = entity.CategoryId
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<Product> DeleteAsync(int Id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(u=>u.Id == Id);
            if (product == null)
            {
                return null;
            }
            product.Is_Active = false;
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return product;
        }
    }
}
