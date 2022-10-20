using ECommerce.Application.Responses.Payment;
using MediatR;

namespace ECommerce.Application.CQRS.Querys.CalculatePayment
{
    public class CalculatePaymentQuery : IRequest<CalculatePaymentDto>
    {
        public int BasketId { get; set; }
        public int Discount { get; set; }
    }
}
