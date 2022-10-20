using ECommerce.Domain.Common;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities
{
    public class Order : BaseEntity
    {
        public DeliveryStatus DeliveryStatus { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }
        public double TotalAmount { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}
