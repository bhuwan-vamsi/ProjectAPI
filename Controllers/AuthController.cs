using ManagerTest.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ManagerTest.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Regsiter([FromBody] RegisterRequestDto registerRequest)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequest.UserName,
                Email = registerRequest.UserName
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerRequest.Password);
            if (identityResult.Succeeded)
            {
                if(registerRequest.Role != null && registerRequest.Role.Any())
                {
                    identityResult = await userManager.AddToRoleAsync(identityUser, registerRequest.Role);
                    if(identityResult.Succeeded)
                    {
                        return Ok("User Registered");
                    }
                }
            }
            return BadRequest("Something Went Wrong");
        }
        //Wroking on Login
        //[HttpPost]
        //[Route("Login")]
        //public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        //{
        //    var user = await userManager.FindByEmailAsync(loginRequest.UserName);
        //    if (user != null)
        //    {
        //        var checkPassword = await userManager.CheckPasswordAsync(user, loginRequest.Password);
        //        if (checkPassword)
        //        {
        //            return Ok("Login Successful");
        //        }
        //        return BadRequest("Invalid Password");
        //    }
        //    return BadRequest("Invalid User Name or Password");
        //}
    }
}
