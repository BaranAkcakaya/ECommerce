using ECommerce.Application.Responses;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.CreateBasket
{
    public class CreateBasketCommand : IRequest<CreateBasketDto>
    {
    }
}
