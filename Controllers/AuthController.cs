using APIPractice.Model.DTO;
using APIPractice.Repository;
using APIPractice.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APIPractice.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Regsiter([FromBody] RegisterRequestDto registerRequest)
        {
            var identityUser = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = registerRequest.UserName,
                Email = registerRequest.UserName
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerRequest.Password);
            if (identityResult.Succeeded)
            {
                if (registerRequest.Roles != null && registerRequest.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequest.Roles);
                    if (identityResult.Succeeded)
                    {
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
