using APIPractice.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace APIPractice.Services.IService
{
    public interface IAuthService
    {
        Task RegisterEmployee(RegisterEmployeeRequest registerCustomerRequest);
        Task<LoginResponseDto> LoginUser(LoginRequest loginUserRequest);
    }
}
