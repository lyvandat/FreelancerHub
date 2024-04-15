using AutoMapper;
using DeToiServerPayment.Dtos;
using DeToiServerPayment.Models;

namespace DeToiServerPayment.AutoMapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderPlacedDto>().ReverseMap();
        }
    }
}
