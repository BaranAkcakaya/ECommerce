using AutoMapper;
using ECommerce.Application.CQRS.Commands.CreateOrder;
using ECommerce.Application.Requests;

namespace ECommerce.Application.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<CreateOrderRequest, CreateOrderCommand>();
        }
    }
}
