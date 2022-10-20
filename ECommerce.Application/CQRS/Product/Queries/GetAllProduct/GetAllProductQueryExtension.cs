using ECommerce.Application.Responses;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.Queries.GetAllProduct
{
    public static class GetAllProductQueryExtension
    {
        public static GetAllProductDto Map(this Product product)
        {
            return new()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Currency = product.Currency
            };
        }
    }
}
