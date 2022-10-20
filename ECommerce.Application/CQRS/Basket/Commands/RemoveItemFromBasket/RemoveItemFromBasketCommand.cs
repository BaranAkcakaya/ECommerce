using ECommerce.Application.Responses;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.RemoveItemFromBasket
{
    public class RemoveItemFromBasketCommand : IRequest<RemoveItemFromBasketDto>
    {
        public int BasketId { get; set; }
        public int BasketItemId { get; set; }
    }
}
