using ECommerce.Application.Responses.Payment;
using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.Querys.CalculatePayment
{
    public static class CalculatePaymentQueryExtension
    {
        public static CalculatePaymentDto Map(this CalculatePaymentQuery request, double amount, double discountAmount)
        {
            return new()
            {
                Amount = amount,
                BasketId = request.BasketId,
                Currency = Currency.TRY,
                Discount = request.Discount,
                DiscountAmount = discountAmount
            };

        }
    }
}
