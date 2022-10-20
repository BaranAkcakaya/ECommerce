using ECommerce.Application.Responses;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.DeleteBasket
{
    public class DeleteBasketCommand : IRequest<DeleteBasketDto>
    {
    }
}
