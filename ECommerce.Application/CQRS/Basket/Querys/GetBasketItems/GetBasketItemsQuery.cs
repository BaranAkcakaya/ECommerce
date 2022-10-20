using ECommerce.Application.Responses;
using MediatR;

namespace ECommerce.Application.CQRS.Querys.GetBasketItems
{
    public class GetBasketItemsQuery : IRequest<List<GetBasketItemsDto>>
    {
        public int BasketId { get; set; }
    }
}
