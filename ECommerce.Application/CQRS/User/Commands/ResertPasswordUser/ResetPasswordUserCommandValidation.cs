using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.User.Commands.ResertPasswordUser
{
    public class ResetPasswordUserCommandValidation : AbstractValidator<ResetPasswordUserCommand>
    {
        public ResetPasswordUserCommandValidation()
        {
            RuleFor(p => p.Email)
                .EmailAddress();
        }
    }
}
