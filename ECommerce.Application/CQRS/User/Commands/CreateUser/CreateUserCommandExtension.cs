using ECommerce.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.User.Commands.CreateUser
{
    public static class CreateUserCommandExtension
    {
        public static AppUser Map(this CreateUserCommand createUserCommand)
        {
            return new()
            {
                Email = createUserCommand.Email,
                UserName = createUserCommand.UserName,
                PhoneNumber = createUserCommand.PhoneNumber
            };
        }
    }
}
