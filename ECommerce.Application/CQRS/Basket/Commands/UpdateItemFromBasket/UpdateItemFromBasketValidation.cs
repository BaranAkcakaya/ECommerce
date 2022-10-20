using FluentValidation;

namespace ECommerce.Application.CQRS.Commands.UpdateItemFromBasket
{
    public class UpdateItemFromBasketValidation : AbstractValidator<UpdateItemFromBasketCommand>
    {
        public UpdateItemFromBasketValidation()
        {
            RuleFor(x => x.Quantity)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Quantity alanı zorunludur.")
                .GreaterThan(0)
                    .WithMessage("Quantity alanı 0'dan büyük olmalıdır.");

            RuleFor(x => x.BasketItemId)
                .NotEmpty()
                .NotNull()
                    .WithMessage("BasketItemId alanı zorunludur.")
                .GreaterThan(0)
                    .WithMessage("BasketItemId alanı 0'dan büyük olmalıdır.");
        }
    }
}
