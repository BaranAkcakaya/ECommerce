using ECommerce.Domain.Common;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Responses
{
    public class GetBasketItemsDto
    {
        public int BasketItemId { get; set; }
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
