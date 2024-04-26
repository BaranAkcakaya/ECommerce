using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.Role.Query.GetRoleById
{
    public class GetRoleByIdQueryValidation : AbstractValidator<GetRoleByIdQuery>
    {
        public GetRoleByIdQueryValidation()
        {
            RuleFor(p => p.RoleId)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Kullanıcı Adı boş olamaz.")
                .GreaterThan(0);
        }
    }
}
