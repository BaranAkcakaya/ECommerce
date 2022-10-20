using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces.Token;
using ECommerce.Application.Responses.User;
using ECommerce.Domain.Common;
using ECommerce.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace ECommerce.Application.CQRS.User.Command.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenDto>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommandHandler(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IConfiguration configuration)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
        }

        public async Task<RefreshTokenDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(p => p.RefreshToken == request.RefreshToken);

            if (user == null)
                throw new UserNotFoundException("Kullanıcı bulunamadı.");

            if (user.RefreshTokenEndDate < DateTime.UtcNow)
                throw new UserException("Kullanıcı zaman aşımına uğradı.");

            var token = _tokenHandler.CreateAccessToken(Int32.Parse(_configuration["Token:TokenLifeTime"]), user);
            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenEndDate = token.Expiration.AddMinutes(Int32.Parse(_configuration["Token:RefreshTokenLifeTime"]));

            await _userManager.UpdateAsync(user);

            return new()
            {
               Token = token
            };
        }
    }
}
