using Microsoft.AspNetCore.Mvc;
using APIPractice.Services;
using APIPractice.Models;

namespace APIPractice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly ItemService _itemService;

        public InventoryController(ItemService itemService)
        {
            _itemService = itemService;
        }

        // GET: api/inventory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            var items = await _itemService.GetAllItemsAsync();
            return Ok(items);
        }

        // GET: api/inventory/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetById(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST: api/inventory
        [HttpPost]
        public async Task<ActionResult> Create(Item item)
        {
            await _itemService.AddItemAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // PUT: api/inventory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Item item)
        {
            if (id != item.Id)
                return BadRequest("ID mismatch");

            await _itemService.UpdateItemAsync(item);
            return NoContent();
        }

        // DELETE: api/inventory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            if (item == null)
                return NotFound();

            await _itemService.DeleteItemAsync(id);
            return NoContent();
        }
    }

}
