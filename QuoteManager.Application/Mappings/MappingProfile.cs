using AutoMapper;
using QuoteManager.Application.DTOs;
using QuoteManager.Core.Entities;

namespace QuoteManager.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Quote, QuoteDto>().ReverseMap();
            CreateMap<QuoteItem, QuoteItemDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
