using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.Role.Command.CreateRole
{
    public class CreateRoleCommandValidation : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidation()
        {
            RuleFor(p => p.RoleName)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Kullanıcı Adı boş olamaz.")
                .MinimumLength(2)
                    .WithMessage("Kullanıcı Adı en az 2 karakterden oluşmalı.")
                .Matches("^[a-zA]*$")
                    .WithMessage("Sadece karakter içermeli.");
        }
    }
}
