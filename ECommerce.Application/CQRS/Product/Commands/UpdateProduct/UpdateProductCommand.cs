using ECommerce.Application.Responses;
using ECommerce.Domain.Enums;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdateProductDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public Currency Currency { get; set; }
    }
}
