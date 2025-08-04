using APIPractice.Models.Domain;

namespace APIPractice.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesAsync();
    }
}
