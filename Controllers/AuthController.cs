using APIPractice.Models.DTO;
using APIPractice.Repository;
using APIPractice.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APIPractice.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;
        private readonly IRegisterUserRepository userRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository, IRegisterUserRepository userRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
            this.userRepository = userRepository;
        }
        [HttpPost]
        [Route("Register")]
        [Authorize("Manager")]
        public async Task<IActionResult> Regsiter([FromBody] RegisterRequestDto registerRequest)
        {
            var managerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var identityUser = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = registerRequest.UserName,
                Email = registerRequest.UserName
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerRequest.Password);
            if (identityResult.Succeeded)
            {
                if (registerRequest.Role!=null && registerRequest.Role.ToLower() != "customer")
                {
                    identityResult = await userManager.AddToRoleAsync(identityUser, registerRequest.Role);
                    if (identityResult.Succeeded)
                    {
                        if (registerRequest.Role.ToLower() == "manager")
                        {
                            var user = userRepository.AddManager(registerRequest, identityUser, managerId);
                        }
                        else if (registerRequest.Role.ToLower() == "employee")
                        {
                            var user = userRepository.AddEmployee(registerRequest, identityUser);
                        }                        
                        return Ok("User Registered");
                    }
                }
            }
            return BadRequest("Something Went Wrong");
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            var user = await userManager.FindByEmailAsync(loginRequest.UserName);
            if (user != null)
            {
                var checkPassword = await userManager.CheckPasswordAsync(user, loginRequest.Password);
                if (checkPassword)
                {
                    var role = await userManager.GetRolesAsync(user);
                    if (role != null)
                    {
                        var jwtToken = tokenRepository.CreateJWTToken(user, role.First());
                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };
                        return Ok(response);
                    }
                    return BadRequest("Something Went Wrong");

                }
                return BadRequest("Invalid Password");
            }
            return BadRequest("Invalid User Name or Password");
        }
    }
}
