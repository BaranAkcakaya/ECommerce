using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Responses.Payment
{
    public class CalculatePaymentDto
    {
        public int BasketId { get; set; }
        public double Amount { get; set; }
        public Currency Currency { get; set; }
        public int Discount { get; set; }
        public double DiscountAmount { get; set; }
    }
}
