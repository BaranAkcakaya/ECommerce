using ECommerce.Domain.Common;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public string CartNumber { get; set; }
        public string NameOnCard { get; set; }
        public double Amount { get; set; }
        public Currency Currency { get; set; }
        public int Discount { get; set; }
        public double DiscountAmount { get; set; }
        public PaymentOption PaymentOption { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}
