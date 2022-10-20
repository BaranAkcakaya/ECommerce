using ECommerce.Application.CQRS.Queries.GetByIdProduct;
using ECommerce.Domain.Common;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;

namespace ECommerce.Application.Responses
{
    public class GetByIdProductDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public Currency Currency { get; set; }
    }
}
