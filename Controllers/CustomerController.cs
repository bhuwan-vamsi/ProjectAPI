using APIPractice.Models.Domain;
using APIPractice.CustomAcitonFilters;
using APIPractice.Models.DTO;
using APIPractice.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using APIPractice.Models.Responses;

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
        [ValidateModel]
        [Authorize(Roles ="Customer")]
        public async Task<IActionResult> ViewProfile()
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity == null)
                {
                    return Unauthorized("User identity not found.");
                }
                CustomerDto? customer = await customerService.ViewProfile(identity);
                return Ok(OkResponse<CustomerDto>.Success(customer));
            }
            catch (Exception ex)
            {
                return BadRequest(BadResponse<string>.Execute(ex.Message));
            }
        }

        [HttpPost]
        [Route("EditProfile")]
        [ValidateModel]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> EditProfile([FromBody] EditProfileRequest request)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                if(identity == null)
                {
                    return Unauthorized("User identity not found.");
                }
                await customerService.EditProfile(identity, request);
                return NoContent();
            }catch (Exception ex)
            {
                return BadRequest(BadResponse<string>.Execute(ex.Message));
            }
        }

        [HttpGet]
        [ValidateModel]
        [Authorize(Roles ="Customer, Manager")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                List<CategoryDto> categories = await customerService.GetCategories();
                return Ok(OkResponse<List<CategoryDto>>.Success(categories));
            }
            catch (Exception ex)
            {
                return BadRequest(BadResponse<string>.Execute(ex.Message));
            }
        }
    }
}
