using APIPractice.Data;
using APIPractice.Models.Domain;
using APIPractice.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace APIPractice.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext db;

        public CustomerRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Customer> GetById(Guid id)
        {
            Customer? customer = await db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                throw new Exception("User Not Found");
            }
            return customer;
        }
    }
}
