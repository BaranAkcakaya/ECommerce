using ECommerce.Application.Requests;
using ECommerce.Application.Responses;
using ECommerce.Application.Responses.Payment;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.Commands.CreatePayment
{
    public static class CreatePaymentCommandExtension
    {
        public static Payment Map(this CreatePaymentCommad request)
        {
            return new()
            {
                CartNumber = request.CartNumber,
                Discount = request.Discount,
                NameOnCard = request.NameOnCard,
                PaymentOption = request.PaymentOption,
                Currency = request.Currency,
                Amount = request.Amount,
                DiscountAmount = request.DiscountAmount,
                BasketId = request.BasketId,
                IsDeleted = false
            };
        }

        public static CreatePaymentCommad Map(this CalculatePaymentDto calculate, CreatePaymentRequest request)
        {
            return new()
            {
                CartNumber = request.CartNumber,
                Discount = calculate.Discount,
                NameOnCard = request.NameOnCard,
                PaymentOption = request.PaymentOption,
                Currency = calculate.Currency,
                Amount = calculate.Amount,
                DiscountAmount = calculate.DiscountAmount,
                BasketId = request.BasketId
            };
        }
    }
}
