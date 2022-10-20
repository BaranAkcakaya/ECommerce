using FluentValidation;

namespace ECommerce.Application.CQRS.Commands.RemoveItemFromBasket
{
    public class RemoveItemFromBasketCommandValidation : AbstractValidator<RemoveItemFromBasketCommand>
    {
        public RemoveItemFromBasketCommandValidation()
        {
            RuleFor(x => x.BasketId)
                .NotEmpty()
                .NotNull()
                    .WithMessage("BasketId alanı zorunludur.")
                .GreaterThan(0)
                    .WithMessage("BasketId alanı 0'dan büyük olmalıdır.");

            RuleFor(x => x.BasketItemId)
                .NotEmpty()
                .NotNull()
                    .WithMessage("BasketItemId alanı zorunludur.")
                .GreaterThan(0)
                    .WithMessage("BasketItemId alanı 0'dan büyük olmalıdır.");
        }
    }
}
