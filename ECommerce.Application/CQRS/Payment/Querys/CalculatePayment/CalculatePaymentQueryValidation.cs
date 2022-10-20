using ECommerce.Application.CQRS.Querys.CalculatePayment;
using FluentValidation;

namespace ECommerce.Application.CQRS.Querys.CalculatePayment
{
    public class CalculatePaymentQueryValidation : AbstractValidator<CalculatePaymentQuery>
    {
        public CalculatePaymentQueryValidation()
        {
            RuleFor(p => p.BasketId)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Amount alanı zorunludur.")
                .GreaterThan(0)
                    .WithMessage("Amount alanı O'dan büyük olmalıdır.");

            RuleFor(p => p.Discount)
                .GreaterThan(-1)
                .LessThan(101)
                    .WithMessage("DiscountAmount alanı O-100 arasında olmalıdır.");
        }
    }
}
