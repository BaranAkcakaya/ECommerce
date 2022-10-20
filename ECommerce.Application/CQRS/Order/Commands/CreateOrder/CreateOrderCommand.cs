using ECommerce.Application.Responses;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderDto>
    {
        public string Address { get; set; }
        public int BasketId { get; set; }
    }
}
