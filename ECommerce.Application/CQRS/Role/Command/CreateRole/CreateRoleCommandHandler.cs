using ECommerce.Application.Responses.Role;
using ECommerce.Domain.Identity;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Application.CQRS.Role.Command.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, CreateRoleDto>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public CreateRoleCommandHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<CreateRoleDto> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new AppRole { Name = request.RoleName};
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
                return new();

            throw new ValidationException(String.Join(";", result.Errors.Select(x => x.Description)));

        }
    }
}
