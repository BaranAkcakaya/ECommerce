using FluentValidation;

namespace ECommerce.Application.CQRS.User.Commands.UpdatePasswordUser
{
    public class UpdatePasswordUserCommandValidation : AbstractValidator<UpdatePasswordUserCommand>
    {
        public UpdatePasswordUserCommandValidation()
        {
            RuleFor(p => p.Password)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Name alanı zorunludur.")
                .MinimumLength(2)
                    .WithMessage("Name alanı minimum 2 karakter içerir.");

            RuleFor(p => p.Token)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Token alanı zorunludur.");

            RuleFor(p => p.UserId)
                .NotEmpty()
                .NotNull()
                    .WithMessage("UserId alanı zorunludur.");
        }
    }
}
