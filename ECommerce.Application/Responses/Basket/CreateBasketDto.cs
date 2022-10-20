using ECommerce.Domain.Entities;

namespace ECommerce.Application.Responses
{
    public class CreateBasketDto
    {
        public int BasketId { get; set; }
        public int UserId { get; set; }
    }
}
