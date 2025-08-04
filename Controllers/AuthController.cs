using APIPractice.CustomAcitonFilters;
using APIPractice.Models.DTO;
using APIPractice.Models.Responses;
using APIPractice.Repository;
using APIPractice.Repository.IRepository;
using APIPractice.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Security.Claims;

namespace APIPractice.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        [Route("Login")]
        [ValidateModel]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var response = await authService.LoginUser(loginRequest);
                return Ok(OkResponse<LoginResponseDto>.Success(response));
            }
            catch (AuthenticationException ex)
            {
                return Unauthorized(UnauthorisedResponse<string>.Execute(ex.Message));
            }
            catch (ArgumentException ex)
            {
                return Unauthorized(UnauthorisedResponse<string>.Execute(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(BadResponse<string>.Execute(ex.Message));
            }
        }

        [HttpPost]
        [ValidateModel]
        [Route("RegisterCustomer")]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerRequest registerCustomerRequest)
        {
            try
            {
                await authService.RegisterCustomer(registerCustomerRequest);
                return Created();
            }catch(Exception ex)
            {
                return BadRequest(BadResponse<string>.Execute(ex.Message));
            }
        }
    }
}
