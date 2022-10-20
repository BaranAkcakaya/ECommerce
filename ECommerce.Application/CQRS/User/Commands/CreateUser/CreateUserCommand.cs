using ECommerce.Application.Responses.User;
using MediatR;

namespace ECommerce.Application.CQRS.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
