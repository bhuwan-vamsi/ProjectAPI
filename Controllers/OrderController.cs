using APIPractice.Models.Domain;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpPost]
        [Route("CheckOut")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> CheckOut([FromBody]OrderDto orders)
        {
            try
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                await orderService.CheckOut(orders, claimsIdentity);
                return Ok("Your Order was successfull");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("ViewHistory")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> ViewHistory()
        {
            try
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                List<OrderHistoryDto> history = await orderService.ViewHistory(claimsIdentity);
                return Ok(history);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("VewOrder/{id:Guid}")]
        [Authorize(Roles ="Customer")]
        public async Task<IActionResult> ViewOrderById([FromRoute] Guid id)
        {
            try
            {
                var identityUser = (ClaimsIdentity)User.Identity;
                Order order = await orderService.ViewOrderById(id,identityUser);
                return Ok(order);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
///<summar>
/// OrderDto
/// OrderItemsDTO
/// OrderDto -> List<OrderItemsDto>
/// 
/// var claimsIdentity = (ClaimsIdentity)User.Identity;
/// 
/// { {id=1,productname="babycare"} , {...} , {...} }
/// </summar>