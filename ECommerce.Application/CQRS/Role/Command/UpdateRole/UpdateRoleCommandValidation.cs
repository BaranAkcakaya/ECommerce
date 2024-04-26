using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.Role.Command.UpdateRole
{
    public class UpdateRoleCommandValidation : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidation()
        {
            RuleFor(p => p.RoleId)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Kullanıcı Adı boş olamaz.")
                .GreaterThan(0);

            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Kullanıcı Adı boş olamaz.")
                .MinimumLength(2)
                .MaximumLength(50);
        }
    }
}
