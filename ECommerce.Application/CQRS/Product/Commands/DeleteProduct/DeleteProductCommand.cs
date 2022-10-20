using ECommerce.Application.Responses;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<DeleteProductDto>
    {
        public int Id { get; set; }
    }
}
