using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuoteManager.Application.DTOs;
using QuoteManager.Application.Interfaces;
using QuoteManager.Core.Entities;
using QuoteManager.Infrastructure.Data;

namespace QuoteManager.Application.Services
{
    public class QuoteItemService(QuoteDbContext context, IMapper mapper) : IQuoteItemService
    {
        public async Task<QuoteItemDto> CreateQuoteAsync(QuoteItemDto quoteItemDto)
        {
            var quoteItem = mapper.Map<QuoteItem>(quoteItemDto);
            context.QuoteItems.Add(quoteItem);
            await context.SaveChangesAsync();
            return mapper.Map<QuoteItemDto>(quoteItem);
        }

        public async Task<bool> DeleteQuoteItemAsync(Guid id)
        {
            var quoteItem = await context.QuoteItems.FindAsync(id);
            if (quoteItem == null)
                return false;

            context.QuoteItems.Remove(quoteItem);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<QuoteItemDto?> GetQuoteItemByIdAsync(Guid id)
        {
            var quoteItem = await context.QuoteItems.FirstOrDefaultAsync(q => q.Id == id);
            return quoteItem == null ? null : mapper.Map<QuoteItemDto>(quoteItem);
        }

        public async Task<IEnumerable<QuoteItemDto>> GetQuoteItemsByQuoteId(Guid quoteId)
        {
            var quote = await context.Quotes.Include(q => q.Items)
                .FirstOrDefaultAsync(q => q.Id == quoteId);

            if (quote == null || quote.Items == null)
                return [];

            return mapper.Map<IEnumerable<QuoteItemDto>>(quote.Items);
        }

        public async Task<bool> UpdateQuoteItemAsync(Guid id, QuoteItemDto quoteItemDto)
        {
            var existingQuoteItem = await context.QuoteItems.FirstOrDefaultAsync(q => q.Id == id);

            if (existingQuoteItem == null) 
                return false;

            mapper.Map(quoteItemDto, existingQuoteItem);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
