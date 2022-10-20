using ECommerce.Application.Exceptions;
using ECommerce.Application.Responses.User;
using ECommerce.Domain.Common;
using ECommerce.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Web;

namespace ECommerce.Application.CQRS.User.Commands.UpdatePasswordUser
{
    public class UpdatePasswordUserCommandHandler : IRequestHandler<UpdatePasswordUserCommand, UpdatePasswordUserDto>
    {
        private readonly UserManager<AppUser> _userManager;

        public UpdatePasswordUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UpdatePasswordUserDto> Handle(UpdatePasswordUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user == null)
                throw new UserNotFoundException("Böyle bir kullanıcı yok.");

            var response = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);
            //var response = await _userManager.ResetPasswordAsync(user, HttpUtility.UrlDecode(request.Token), request.Password);

            if (!response.Succeeded)
                throw new UserException("Parola değiştirme işlemi başarısız.");

            await _userManager.UpdateSecurityStampAsync(user);

            return new();
        }
    }
}
