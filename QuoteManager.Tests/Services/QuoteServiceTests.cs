using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using QuoteManager.Application.DTOs;
using QuoteManager.Application.Services;
using QuoteManager.Core.Entities;
using QuoteManager.Infrastructure.Data;

namespace QuoteManager.Tests.Services
{
    public class QuoteServiceTests
    {
        private readonly QuoteService _quoteService;
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly QuoteDbContext _dbContext;

        public QuoteServiceTests()
        {
            var options = new DbContextOptionsBuilder<QuoteDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _dbContext = new QuoteDbContext(options);
            _quoteService = new QuoteService(_dbContext, _mapperMock.Object);
        }

        [Fact]
        public async Task CreateQuoteAsync_Should_Create_Quote_And_Return_Dto()
        {
            var userId = Guid.NewGuid();
            var quoteDto = new QuoteDto { Title = "Test Quote", UserId = userId };
            var quoteEntity = new Quote { Id = Guid.NewGuid(), Title = quoteDto.Title, UserId = quoteDto.UserId, CreatedAt = DateTime.UtcNow };
            var returnedDto = new QuoteDto { Id = quoteEntity.Id, Title = quoteEntity.Title, UserId = quoteEntity.UserId };

            _mapperMock.Setup(m => m.Map<Quote>(quoteDto)).Returns(quoteEntity);
            _mapperMock.Setup(m => m.Map<QuoteDto>(It.IsAny<Quote>())).Returns(returnedDto);

            var result = await _quoteService.CreateQuoteAsync(quoteDto);

            Assert.NotNull(result);
            Assert.Equal(quoteDto.Title, result.Title);
            Assert.Equal(quoteDto.UserId, result.UserId);
        }

        [Fact]
        public async Task GetQuoteByIdAsync_Should_Return_Quote_If_Found()
        {
            var quote = new Quote { Id = Guid.NewGuid(), Title = "Test", UserId = Guid.NewGuid(), CreatedAt = DateTime.UtcNow };
            await _dbContext.Quotes.AddAsync(quote);
            await _dbContext.SaveChangesAsync();

            var expectedDto = new QuoteDto { Id = quote.Id, Title = quote.Title, UserId = quote.UserId };
            _mapperMock.Setup(m => m.Map<QuoteDto>(quote)).Returns(expectedDto);

            var result = await _quoteService.GetQuoteByIdAsync(quote.Id);

            Assert.NotNull(result);
            Assert.Equal(quote.Id, result.Id);
        }

        [Fact]
        public async Task UpdateQuoteAsync_Should_Return_True_If_Successful()
        {
            var id = Guid.NewGuid();
            var original = new Quote { Id = id, Title = "Old", UserId = Guid.NewGuid(), CreatedAt = DateTime.UtcNow };
            await _dbContext.Quotes.AddAsync(original);
            await _dbContext.SaveChangesAsync();

            var updatedDto = new QuoteDto { Id = id, Title = "New", UserId = original.UserId };
            _mapperMock.Setup(m => m.Map(It.IsAny<QuoteDto>(), It.IsAny<Quote>())).Callback<QuoteDto, Quote>((dto, q) => q.Title = dto.Title);

            var result = await _quoteService.UpdateQuoteAsync(id, updatedDto);

            Assert.True(result);
            Assert.Equal("New", _dbContext.Quotes.First().Title);
        }
    }
}
