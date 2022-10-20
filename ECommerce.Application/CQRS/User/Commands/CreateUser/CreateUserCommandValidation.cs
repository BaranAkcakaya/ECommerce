using FluentValidation;

namespace ECommerce.Application.CQRS.User.Commands.CreateUser
{
    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            RuleFor(p => p.UserName)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Kullanıcı Adı boş olamaz.")
                .MinimumLength(4)
                    .WithMessage("Kullanıcı Adı en az 4 karakterden oluşmalı.")
                .Matches("^[a-zA-Z0-9]*$")
                    .WithMessage("Sadece sayı ve karakter içermeli.");

            RuleFor(p => p.Email)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Email boş olamaz.")
                .EmailAddress()
                    .WithMessage("Email bilgisini doğru girin.");

            RuleFor(p => p.PhoneNumber)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Telefon NUmarası zorunludur.")
                .MinimumLength(10)
                    .WithMessage("Telefon Numarası 10 karakterden küçük olamaz.")
                .MaximumLength(20)
                    .WithMessage("Telefon Numarası çok uzun.")
                .Matches(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$")
                    .WithMessage("Telefon Numarası geçersiz.");
        }
    }
}
