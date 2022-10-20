using ECommerce.Application.Responses.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.User.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserDto>
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
        public int FailedCount { get; set; }
    }
}
