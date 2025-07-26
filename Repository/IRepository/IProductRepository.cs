using APIPractice.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace APIPractice.Repository.IRepository
{
    public interface IProductRepository<Product> where Product : class
    {
        Task <List<Product>> GetAllAsync ();
        Task<Product> GetAsync(Guid id);
        Task<Product> CreateAsync(Product entity);
        Task UpdateAsync(Product existing, UpdateProductDto entity);
        Task DeleteAsync(Product entity);
    }
}
