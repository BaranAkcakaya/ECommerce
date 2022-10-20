using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces.Token;
using ECommerce.Application.Responses.User;
using ECommerce.Domain.Common;
using ECommerce.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.User.Commands.ResertPasswordUser
{
    public class ResetPasswordUserCommandHandler : IRequestHandler<ResetPasswordUserCommand, ResetPasswordUserDto>
    {
        private readonly UserManager<AppUser> _userManager;

        public ResetPasswordUserCommandHandler(UserManager<AppUser> userManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
        }

        public async Task<ResetPasswordUserDto> Handle(ResetPasswordUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                throw new UserNotFoundException("Böyle bir kullanıcı bulunmuyor.");

            var token = _userManager.GeneratePasswordResetTokenAsync(user);
            //mail gönderme işlemleri yapılacak. Şuanlık tokenı geri donuyorum ancak maille gönderilecek.

            return new()
            {
                Token = token.Result
            };
        }
    }
}
