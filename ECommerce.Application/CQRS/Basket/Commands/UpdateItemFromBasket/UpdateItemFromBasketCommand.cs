using ECommerce.Application.Responses;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.UpdateItemFromBasket
{
    public class UpdateItemFromBasketCommand : IRequest<UpdateItemFromBasketDto>
    {
        public int BasketItemId { get; set; }
        public int Quantity { get; set; }
    }
}
