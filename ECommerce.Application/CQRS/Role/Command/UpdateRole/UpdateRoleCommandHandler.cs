using ECommerce.Application.Exceptions;
using ECommerce.Application.Responses.Role;
using ECommerce.Domain.Identity;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace ECommerce.Application.CQRS.Role.Command.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, UpdateRoleDto>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public UpdateRoleCommandHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<UpdateRoleDto> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());
            if (role == null)
                throw new RoleException("This User Not Founed", HttpStatusCode.NotFound);

            role.Name = request.Name;
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
                return new();

            throw new ValidationException(String.Join(";", result.Errors.Select(x => x.Description)));
        }
    }
}
