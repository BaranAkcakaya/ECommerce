using ECommerce.Application.Responses;
using ECommerce.Domain.Enums;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.CreatePayment
{
    public class CreatePaymentCommad : IRequest<CreatePaymentDto>
    {
        public string CartNumber { get; set; }
        public string NameOnCard { get; set; }
        public double Amount { get; set; }
        public Currency Currency { get; set; }
        public int Discount { get; set; }
        public double DiscountAmount { get; set; }
        public PaymentOption PaymentOption { get; set; }
        public int BasketId { get; set; }
    }
}
