using ECommerce.Application.Responses;
using MediatR;

namespace ECommerce.Application.CQRS.Queries.GetByIdProduct
{
    public class GetByIdProductQuery : IRequest<GetByIdProductDto>
    {
        public int Id { get; set; }
    }
}
