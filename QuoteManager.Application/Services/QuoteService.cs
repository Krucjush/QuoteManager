using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuoteManager.Application.DTOs;
using QuoteManager.Application.Interfaces;
using QuoteManager.Core.Entities;
using QuoteManager.Infrastructure.Data;

namespace QuoteManager.Application.Services
{
    public class QuoteService(QuoteDbContext? context, IMapper? mapper) : IQuoteService
    {
        private readonly QuoteDbContext? _context = context;
        private readonly IMapper? _mapper = mapper;

        public async Task<QuoteDto> CreateQuoteAsync(QuoteDto quoteDto)
        {
            var quote = _mapper!.Map<Quote>(quoteDto);
            _context!.Quotes.Add(quote);
            await _context.SaveChangesAsync();
            return _mapper.Map<QuoteDto>(quote);
        }

        public async Task<bool> DeleteQuoteAsync(Guid id)
        {
            var quote = await _context!.Quotes.FindAsync(id);
            if (quote == null)
                return false;

            _context.Quotes.Remove(quote);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<QuoteDto>> GetAllQuotes()
        {
            var quotes = await _context!.Quotes.Include(q => q.Items).ToListAsync();
            return _mapper!.Map<IEnumerable<QuoteDto>>(quotes);
        }

        public async Task<IEnumerable<QuoteDto>> GetQuoteByUserIdAsync(Guid userId)
        {
            var quotes = await _context!.Quotes.Include(q => q.Items)
                .FirstOrDefaultAsync(q => q.UserId == userId);
            return _mapper!.Map<IEnumerable<QuoteDto>>(quotes);
        }

        public async Task<QuoteDto?> GetQuoteByIdAsync(Guid id)
        {
            var quote = await _context!.Quotes.Include(q => q.Items)
                .FirstOrDefaultAsync(q => q.Id == id);
            return quote == null ? null : _mapper!.Map<QuoteDto>(quote);
        }

        public async Task<bool> UpdateQuoteAsync(Guid id, QuoteDto quoteDto)
        {
            var existingQuote = await _context!.Quotes.Include(q => q.Items)
                .FirstOrDefaultAsync(q => q.Id == id);
            if (existingQuote == null)
                return false;

            _mapper!.Map(quoteDto, existingQuote);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
