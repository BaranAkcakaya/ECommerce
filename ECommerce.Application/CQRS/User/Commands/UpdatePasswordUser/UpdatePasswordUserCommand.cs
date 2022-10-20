using ECommerce.Application.Responses.User;
using MediatR;

namespace ECommerce.Application.CQRS.User.Commands.UpdatePasswordUser
{
    public class UpdatePasswordUserCommand : IRequest<UpdatePasswordUserDto>
    {
        public string Password { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
