using APIPractice.Models.Domain;

namespace APIPractice.Repository.IRepository
{
    public interface ICustomerRepository
    {
        public Task<Customer> GetById(Guid id);
    }
}
