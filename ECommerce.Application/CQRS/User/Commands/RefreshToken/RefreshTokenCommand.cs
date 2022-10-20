using ECommerce.Application.Responses.User;
using MediatR;

namespace ECommerce.Application.CQRS.User.Command.RefreshToken
{
    public class RefreshTokenCommand : IRequest<RefreshTokenDto>
    {
        public string RefreshToken { get; set; }
    }
}
