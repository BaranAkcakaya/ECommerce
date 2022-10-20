using FluentValidation;

namespace ECommerce.Application.CQRS.Commands.AddItemToBasket
{
    public class AddItemToBasketCommandValidation : AbstractValidator<AddItemToBasketCommand>
    {
        public AddItemToBasketCommandValidation()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .NotNull()
                    .WithMessage("ProductId alanı zorunludur.")
                .GreaterThan(0)
                    .WithMessage("ProductId alanı 0'dan büyük olmalıdır.");
        }
    }
}
