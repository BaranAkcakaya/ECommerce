using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.Commands.CreatePayment
{
    public class CreatePaymentCommadValidation : AbstractValidator<CreatePaymentCommad>
    {
        public CreatePaymentCommadValidation()
        {
            RuleFor(p => p.CartNumber)
                .NotEmpty()
                .NotNull()
                    .WithMessage("CartNumber alanı zorunludur.")
                .MinimumLength(10)
                .MaximumLength(100)
                    .WithMessage("CartNumber alanı 10-25 karakter içerir.");

            RuleFor(p => p.NameOnCard)
                .NotEmpty()
                .NotNull()
                    .WithMessage("NameOnCard alanı zorunludur.")
                .MinimumLength(1)
                .MaximumLength(50)
                    .WithMessage("NameOnCard alanı O'dan büyük olmalıdır.");

            RuleFor(p => p.BasketId)
                .NotEmpty()
                .NotNull()
                    .WithMessage("BasketId alanı zorunludur.")
                .GreaterThan(-1)
                    .WithMessage("BasketId alanı O'dan büyük olmalıdır.");

            RuleFor(p => p.Amount)
                .GreaterThan(-1)
                    .WithMessage("Amount alanı O'dan büyük olmalıdır.");

            RuleFor(p => p.DiscountAmount)
                .GreaterThan(-1)
                    .WithMessage("DiscountAmount alanı O'dan büyük olmalıdır.");

            RuleFor(p => p.Discount)
                .GreaterThan(-1)
                    .WithMessage("Discount alanı O'dan büyük olmalıdır.");

            RuleFor(p => p.Currency)
                .IsInEnum()
                    .WithMessage("Currency alanı yanlış girildi.");

            RuleFor(p => p.PaymentOption)
                .IsInEnum()
                    .WithMessage("PaymentOption alanı yanlış girildi.");


        }
    }
}
