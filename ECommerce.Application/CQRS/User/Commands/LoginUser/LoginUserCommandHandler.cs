using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces.Token;
using ECommerce.Application.Responses.User;
using ECommerce.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Application.CQRS.User.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserDto>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IConfiguration _configuration;

        public LoginUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
        }

        public async Task<LoginUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserNameOrEmail) ?? await _userManager.FindByEmailAsync(request.UserNameOrEmail);

            if (user == null)
                throw new UserNotFoundException();

            var isLocked = await _userManager.IsLockedOutAsync(user);
            if (isLocked)
            {
                var lockDate = await _userManager.GetLockoutEndDateAsync(user);
                throw new UserException(String.Format("Bu Hesap {0} tarihine kadar kilitlenmiştir.",lockDate));
            }

            var result =  await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            //var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);  //Cookie için
            var failedCount = await _userManager.GetAccessFailedCountAsync(user);

            if(failedCount == 3)
            {
                await _userManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.UtcNow.AddMinutes(request.FailedCount)));
                throw new Exception(String.Format("Ard arda çok fazla başarız giriş denemesi yaptığınızdan dolayı hesabınız {0} dk kilitlenmiştir.",request.FailedCount));
            }


            if (!result.Succeeded)
            {
                await _userManager.AccessFailedAsync(user);
                throw new UserNotFoundException();
            }

            await _userManager.ResetAccessFailedCountAsync(user);
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
