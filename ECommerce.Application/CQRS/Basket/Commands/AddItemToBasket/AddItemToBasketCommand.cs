using ECommerce.Application.Responses;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.AddItemToBasket
{
    public class AddItemToBasketCommand : IRequest<AddItemToBasketDto>
    {
        public int BasketId { get; set; }
        public int ProductId { get; set; }
    }
}
