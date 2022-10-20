using ECommerce.Application.Requests;
using FluentValidation;

namespace ECommerce.Application.CQRS.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Id alanı zorunludur.")
                .GreaterThan(0)
                    .WithMessage("Id alnı 0'dan büyük olmalıdır");
        }
    }
}
