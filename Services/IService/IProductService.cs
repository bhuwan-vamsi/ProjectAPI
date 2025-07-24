using APIPractice.Models.Domain;
using APIPractice.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace APIPractice.Services.IService
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductAsync();
        Task<ProductDto> GetProductAsync(int id);
        Task<Product> CreateProductAsync(CreateProductDto product);
        Task UpdateProductAsync(int id, UpdateProductDto product);
        Task DeleteProductAsync(int id);
    }
}
