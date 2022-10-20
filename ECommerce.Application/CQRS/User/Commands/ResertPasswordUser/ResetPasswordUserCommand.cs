using ECommerce.Application.Responses.User;
using MediatR;

namespace ECommerce.Application.CQRS.User.Commands.ResertPasswordUser
{
    public class ResetPasswordUserCommand : IRequest<ResetPasswordUserDto>
    {
        public string Email { get; set; }
    }
}
