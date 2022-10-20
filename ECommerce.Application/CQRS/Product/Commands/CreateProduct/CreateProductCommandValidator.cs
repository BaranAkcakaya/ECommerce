using ECommerce.Application.Requests;
using ECommerce.Domain.Enums;
using FluentValidation;

namespace ECommerce.Application.CQRS.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
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
