using ECommerce.Application.Responses;
using MediatR;

namespace ECommerce.Application.CQRS.Queries.GetAllProduct
{
    public class GetAllProductQuery : IRequest<List<GetAllProductDto>>
    {
    }
}
