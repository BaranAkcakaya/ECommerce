using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.Role.Command.DeleteRole
{
    public class DeleteRoleCommandValidation : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleCommandValidation()
        {
            RuleFor(p => p.RoleId)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Kullanıcı Adı boş olamaz.")
                .GreaterThan(0);
        }
    }
}
