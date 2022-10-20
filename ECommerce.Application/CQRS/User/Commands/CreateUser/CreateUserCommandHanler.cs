using ECommerce.Application.Responses.User;
using ECommerce.Domain.Identity;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Application.CQRS.User.Commands.CreateUser
{
    public class CreateUserCommandHanler : IRequestHandler<CreateUserCommand, CreateUserDto>
    {
        private readonly UserManager<AppUser> _userManager;

        public CreateUserCommandHanler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var parameter = request.Map();
            var result = await _userManager.CreateAsync(parameter, request.Password);

            if (result.Succeeded)
                return new();

            throw new ValidationException(String.Join(";",result.Errors.Select(x => x.Description))); 
        }
    }
}
