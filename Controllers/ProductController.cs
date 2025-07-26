using AutoMapper;
using APIPractice.CustomAcitonFilters;
using APIPractice.Models.Domain;
using APIPractice.Models.DTO;
using APIPractice.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using APIPractice.Services.IService;

namespace APIPractice.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        [ValidateModel]
        [Authorize(Roles = "Employee,Manager")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await productService.GetAllProductAsync());
            }
            catch (KeyNotFoundException ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Employee,Manager")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                return Ok(await productService.GetProductAsync(id));
            }
            catch (KeyNotFoundException ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto entity)
        {
            var product = await productService.CreateProductAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, entity);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductDto entity)
        {

            try
            {
                await productService.UpdateProductAsync(id, entity);
                return Ok("Updated Successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            try
            {
                await productService.DeleteProductAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
