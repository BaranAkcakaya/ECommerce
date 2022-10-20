using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.User.Commands.LoginUser
{
    public class LoginUserCommandValidation : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidation()
        {
            RuleFor(p => p.UserNameOrEmail)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Kullanıcı Adı veya Email alanı boş bırakılamaz.");

            RuleFor(p => p.Password)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Password alanı boş bırakılamaz.");
        }
    }
}
