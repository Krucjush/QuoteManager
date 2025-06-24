using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuoteManager.Application.DTOs;
using QuoteManager.Application.Interfaces;

namespace QuoteManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class QuoteController(IQuoteService quoteService) : ControllerBase
    {
        private readonly IQuoteService _quoteService = quoteService;

        [HttpGet("{id}")]
        public async Task<ActionResult<QuoteDto>> GetById(Guid id)
        {
            var quote = await _quoteService.GetQuoteByIdAsync(id);
            if (quote == null)
                return NotFound();
            return Ok(quote);
        }

        [HttpPost]
        public async Task<ActionResult<QuoteDto>> Create([FromBody] QuoteDto quoteDto)
        {
            var created = await _quoteService.CreateQuoteAsync(quoteDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] QuoteDto quoteDto)
        {
            var success = await _quoteService.UpdateQuoteAsync(id, quoteDto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _quoteService.DeleteQuoteAsync(id);
            return success ? NoContent() : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuoteDto>>> GetByUserId(Guid userId)
        {
            var quotes = await _quoteService.GetQuoteByUserIdAsync(userId);
            return Ok(quotes);
        }
    }
}
