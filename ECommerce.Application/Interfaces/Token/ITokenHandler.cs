using ECommerce.Application.Responses.Token;
using ECommerce.Domain.Identity;

namespace ECommerce.Application.Interfaces.Token
{
    public interface ITokenHandler
    {
        TokenHandlerDto CreateAccessToken(int minute, AppUser user);
        string CreateRefreshToken();
    }
}
