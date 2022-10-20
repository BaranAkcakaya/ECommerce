using ECommerce.Application.Responses;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.CQRS.Queries.GetByIdProduct
{
    public static class GetByIdProductQueryExtensions
    {
        public static GetByIdProductDto Map(this Product product)
        {
            return new()
            {
                Price = product.Price,
                Name = product.Name,
                Stock = product.Stock,
                Currency = product.Currency
            };
        }
    }
}
