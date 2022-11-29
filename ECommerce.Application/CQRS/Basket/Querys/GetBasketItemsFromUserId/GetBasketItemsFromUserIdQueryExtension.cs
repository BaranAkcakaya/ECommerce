using ECommerce.Application.Responses;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.Querys.GetBasketItemsFromUserId
{
    public static class GetBasketItemsFromUserIdQueryExtension
    {
        public static GetBasketItemsDto Map(this BasketItem basketItem)
        {
            return new()
            {
                BasketItemId = basketItem.Id,
                BasketId = basketItem.BasketId,
                ProductId = basketItem.ProductId,
                Quantity = basketItem.Quantity
            };
        }
    }
}
