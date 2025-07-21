using AutoMapper;
using APIPractice.CustomAcitonFilters;
using APIPractice.Model.Domain;
using APIPractice.Model.DTO;
using APIPractice.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APIPractice.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> productRepo;
        private readonly IMapper mapper;

        public ProductController(IRepository<Product> productRepo, IMapper mapper)
        {
            this.productRepo = productRepo;
            this.mapper = mapper;
        }
        [HttpGet]
        [ValidateModel]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await productRepo.GetAllAsync();
            var productsdto = mapper.Map<List<ProductDto>>(products);
            return Ok(productsdto);
        }
        [HttpGet]
        [Route("{id}")]
        [ValidateModel]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await productRepo.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var productdto = mapper.Map<ProductDto>(product);
            return Ok(productdto);
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto entity)
        {
            var product = mapper.Map<Product>(entity);
            product = await productRepo.CreateAsync(product);   
            var productDto = mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }
        [HttpPut]
        [Route("{id}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateProduct([FromRoute]int id,[FromBody] UpdateProductDto entity)
        {
            var product = mapper.Map<Product>(entity);
            product = await productRepo.UpdateAsync(id,product);
            var productDto = mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }
        [HttpDelete]
        [Route("{id}")]
        [ValidateModel]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var product = await productRepo.DeleteAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
