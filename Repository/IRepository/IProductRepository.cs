using APIPractice.Models.Domain;
using APIPractice.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace APIPractice.Repository.IRepository
{
    public interface IProductRepository
    {
        Task <List<Product>> GetAllAsync (string? categoryName = null, string? filterQuery = null,string? sortBy=null, bool IsAscending=true, int PageNumber=1, int PageSize=10);
        Task<Product> GetAsync(Guid id);
        Task<Product> CreateAsync(CreateProductDto entity, Guid managerId);
        Task UpdateAsync(Product existing, UpdateProductDto entity, Guid managerId);
        Task UpdateQuantityAsync(Guid id, Product product);
        Task DeleteAsync(Product entity);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<List<Product>> GetAllByIdsAsync(List<Guid> productIds);
        Task UpdateAllQuantityAsync(Dictionary<Guid, Product> productDict);
    }
}
