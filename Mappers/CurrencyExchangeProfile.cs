using AutoMapper;
using MarketApi.DTOs.Address;
using MarketApi.DTOs.CurrencyExchange;
using MarketApi.Models;

namespace MarketApi.Mappers
{
    public class CurrencyExchangeProfile : Profile
    {
        public CurrencyExchangeProfile()
        {
            CreateMap<CurrencyExchange, CurrencyExchangeRequest>()
            .ReverseMap();

            CreateMap<CurrencyExchange, CurrencyExchangeUpdateRequest>()
                    .ReverseMap();

            CreateMap<CurrencyExchange, CurrencyExchangeResponse>()
                .ReverseMap();
        }
    }
}
