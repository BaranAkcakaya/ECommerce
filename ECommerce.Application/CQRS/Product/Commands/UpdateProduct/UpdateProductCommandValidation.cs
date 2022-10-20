using ECommerce.Domain.Entities;
using FluentValidation;

namespace ECommerce.Application.CQRS.Commands.UpdateProduct
{
    public class UpdateProductCommandValidation : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidation()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0)
                    .WithMessage("Id alanı zorunludur.");

            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Name alanı zorunludur.")
                .MinimumLength(3)
                .MaximumLength(100)
                    .WithMessage("Name alanı 2-100 karakter içerir.");

            RuleFor(p => p.Price)
                .GreaterThan(-1d)
                    .WithMessage("Price alanı O'dan büyük olmalıdır.");

            RuleFor(p => p.Stock)
                .GreaterThan(-1)
                    .WithMessage("Stock alanı O'dan büyük olmalıdır.");

            RuleFor(p => p.Currency)
                .IsInEnum()
                    .WithMessage("Currency alanı hatalı girildi");
        }
    }
}
