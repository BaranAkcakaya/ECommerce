using ECommerce.Application.Responses;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.CQRS.Querys.GetBasketItems
{
    public static class GetBasketItemsQueryExtension
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
