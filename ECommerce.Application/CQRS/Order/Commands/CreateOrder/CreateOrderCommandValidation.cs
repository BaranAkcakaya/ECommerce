using FluentValidation;

namespace ECommerce.Application.CQRS.Commands.CreateOrder
{
    public class CreateOrderCommandValidation : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidation()
        {
            RuleFor(p => p.Address)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Adres alanı zorunludur.")
                .MinimumLength(10)
                .MaximumLength(100)
                    .WithMessage("Adres alanı 10-100 karakter içerir.");

            RuleFor(p => p.BasketId)
                .NotEmpty()
                .NotNull()
                    .WithMessage("BasketId alanı zorunludur.")
                .GreaterThan(0)
                    .WithMessage("BasketId alanı O'dan büyük olmalıdır.");
        }
    }
}
