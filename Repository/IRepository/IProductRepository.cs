using APIPractice.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace APIPractice.Repository.IRepository
{
    public interface IProductRepository<Product> where Product : class
    {
        Task <List<Product>> GetAllAsync ();
        Task<Product> GetAsync(Guid id);
        Task<Product> CreateAsync(Product entity);
        Task UpdateAsync(Product existing, UpdateProductDto entity, Guid managerId);
        Task UpdateQuantityAsync(Guid id, Product product);
        Task DeleteAsync(Product entity);
    }
}
