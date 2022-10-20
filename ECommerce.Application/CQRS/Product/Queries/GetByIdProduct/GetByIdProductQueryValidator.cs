using FluentValidation;

namespace ECommerce.Application.CQRS.Queries.GetByIdProduct
{
    public class GetByIdProductQueryValidator : AbstractValidator<GetByIdProductQuery>
    {
        public GetByIdProductQueryValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Id alanı zorunludur.")
                .GreaterThan(0)
                    .WithMessage("Id alanı 0'dan büyük olmalıdır.");
        }
    }
}
