using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuoteManager.Application.DTOs;
using QuoteManager.Application.Interfaces;

namespace QuoteManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class QuoteItemController(IQuoteItemService quoteItemService) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<QuoteItemDto>> GetById(Guid id)
        {
            var item = await quoteItemService.GetQuoteItemByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet("by-quote/{quoteId:guid}")]
        public async Task<ActionResult<IEnumerable<QuoteItemDto>>> GetByQuoteId(Guid quoteId)
        {
            var items = await quoteItemService.GetQuoteItemsByQuoteId(quoteId);
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<QuoteItemDto>> Create(QuoteItemDto quoteItemDto)
        {
            var createdItem = await quoteItemService.CreateQuoteAsync(quoteItemDto);
            return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, QuoteItemDto quoteItemDto)
        {
            var updated = await quoteItemService.UpdateQuoteItemAsync(id, quoteItemDto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await quoteItemService.DeleteQuoteItemAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}