using APIPractice.Models.DTO;
using APIPractice.Models.Responses;
using APIPractice.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            this.statisticService = statisticService;
        }
        [HttpGet]
        [Route("InventorySummary")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetInventorySummary()
        {
            try
            {
                var inventorySummary = await statisticService.InventorySummary();
                return Ok(OkResponse<InventorySummaryDto>.Success(inventorySummary));
            }
            catch (Exception) {
                return BadRequest(BadResponse<string>.Execute("An error occurred while fetching the inventory summary."));
            }
        }
        [HttpGet]
        [Route("CategoryDistribution")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetCategoryDistribuiton()
        {
            try
            {
                var categoryDistribution = await statisticService.CategoryDistribution();
                return Ok(OkResponse<CategoryDistributionDto>.Success(categoryDistribution));
            }
            catch (Exception)
            {
                return BadRequest(BadResponse<string>.Execute("An error occurred while fetching the category distribution."));
            }
        }
        [HttpGet]
        [Route("FastMovingProduct")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetFastMovingProducts()
        {
            try
            {
                var fastMovingProduct = await statisticService.MostSoldProducts();
                return Ok(OkResponse<ProductDto>.Success(fastMovingProduct));
            }
            catch (KeyNotFoundException)
            {
                return NotFound(NotFoundResponse<string>.Execute("No fast moving product found."));
            }
            catch (Exception)
            {
                return BadRequest(BadResponse<string>.Execute("An error occurred while fetching the fast moving product."));
            }
        }
        [HttpGet]
        [Route("ProductPriceAnalysis/{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetProductPriceAnalysis([FromRoute] Guid id)
        {
            try
            {
                var priceAnalysis = await statisticService.ProductPriceAnalysis(id);
                return Ok(priceAnalysis);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(NotFoundResponse<string>.Execute("Product Not Found."));
            }
            catch (Exception)
            {
                return BadRequest(BadResponse<string>.Execute("An error occurred while fetching the product price analysis."));
            }
        }
        [HttpGet]
        [Route("RevenueAnalysis")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetRevenueAnalysis()
        {
            try
            {
                var revenueAnalysis = await statisticService.RevenueAnalysis();
                return Ok(revenueAnalysis);
            }
            catch (Exception)
            {
                return BadRequest(BadResponse<string>.Execute("An error occurred while fetching the revenue analysis"));
            }
        }
    }
}
