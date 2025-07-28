using APIPractice.Models.DTO;
using System.Security.Claims;

namespace APIPractice.Services.IService
{
    public interface ICustomerService
    {
        public Task<CustomerDto> ViewProfile(ClaimsIdentity identity);
    }
}
