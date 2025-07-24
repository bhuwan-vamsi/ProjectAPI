using APIPractice.Data;
using APIPractice.Models.Domain;
using APIPractice.Models.DTO;
using APIPractice.Repository.IRepository;
using Microsoft.AspNetCore.Identity;

namespace APIPractice.Repository
{
    public class RegisterUserRepository : IRegisterUserRepository
    {
        private readonly ApplicationDbContext db;

        public RegisterUserRepository(ApplicationDbContext db) 
        {
            this.db = db;
        }
        public async Task<Customer> AddCustomer(RegisterRequestDto registerRequest, IdentityUser identityUser)
        {
            var user = new Customer
            {
                Id = identityUser.Id,
                Name = registerRequest.Name,
                Address = registerRequest.Address,
                Age = registerRequest.Age,
                IsActive = true
            };
            await db.Customers.AddAsync(user);
            await db.SaveChangesAsync();
            return user;
        }
        public async Task<Employee> AddEmployee(RegisterRequestDto registerRequest, IdentityUser identityUser, Guid managerId)
        {
            var user = new Employee
            {
                Id = identityUser.Id,
                Name = registerRequest.Name,
                ManagerId = managerId,
                Age = registerRequest.Age,
                IsActive = true
            };
            await db.Employees.AddAsync(user);
            await db.SaveChangesAsync();
            return user;
        }
        public async Task<Manager> AddManager(RegisterRequestDto registerRequest, IdentityUser identityUser)
        {
            var user = new Manager
            {
                Id = identityUser.Id,
                Name = registerRequest.Name
            };
            await db.Managers.AddAsync(user);
            await db.SaveChangesAsync();
            return user;
        }
    }
}
