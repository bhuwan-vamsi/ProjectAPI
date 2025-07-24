using APIPractice.Models.Domain;
using APIPractice.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace APIPractice.Repository.IRepository
{
    public interface IRegisterUserRepository
    {
        Task<Customer> AddCustomer(RegisterRequestDto registerRequest, IdentityUser identityUser);
        Task<Employee> AddEmployee(RegisterRequestDto registerRequest, IdentityUser identityUser, Guid id);
        Task<Manager> AddManager(RegisterRequestDto registerRequest, IdentityUser identityUser);
    }
}
