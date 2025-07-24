using APIPractice.Data;
using APIPractice.Models.Domain;
using APIPractice.Models.DTO;
using APIPractice.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace APIPractice.Repository
{
    public class RegisterUserRepository : IRegisterUserRepository
    {
        private readonly ApplicationDbContext db;

        public RegisterUserRepository(ApplicationDbContext db) 
        {
            this.db = db;
        }
        public async Task<Employee> AddEmployee(RegisterEmployeeRequest registerRequest, IdentityUser identityUser)
        {
            var manager = await db.Managers.FirstOrDefaultAsync(u => u.Id == registerRequest.ManagerId.ToString());
            if(manager == null)
            {
                throw new Exception("Invalid Manager Id");
            }
            var user = new Employee
            {
                Id = identityUser.Id,
                Name = registerRequest.Name,
                ManagerId = registerRequest.ManagerId,
                Age = registerRequest.Age,
                IsActive = true
            };
            await db.Employees.AddAsync(user);
            await db.SaveChangesAsync();
            return user;
        }
        public async Task<Manager> AddManager(RegisterManagerRequest registerRequest, IdentityUser identityUser)
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
