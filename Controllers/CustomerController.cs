using APIPractice.Models.DTO;
using APIPractice.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APIPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpGet]
        [Route("ViewProfile")]
        [Authorize(Roles ="Customer")]
        public async Task<IActionResult> ViewProfile()
        {
            try
            {
                ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
                CustomerDto customer = await customerService.ViewProfile(identity);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("EditProfile")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> EditProfile([FromBody] EditProfileRequest request)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                await customerService.EditProfile(identity, request);
                return Ok("Successfully Updated");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
