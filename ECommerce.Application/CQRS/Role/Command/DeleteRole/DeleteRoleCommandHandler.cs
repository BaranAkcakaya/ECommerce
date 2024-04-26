using ECommerce.Application.Exceptions;
using ECommerce.Application.Responses.Role;
using ECommerce.Domain.Identity;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.Role.Command.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, DeleteRoleDto>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public DeleteRoleCommandHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<DeleteRoleDto> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(p => p.Id == request.RoleId); // await _roleManager.FindByIdAsync(request.RoleId.ToString());
            if (role == null)
                throw new RoleException("This Role Not Founed.");

            var result = await _roleManager.DeleteAsync(role);
            if(result.Succeeded)
                return new();

            throw new ValidationException(String.Join(";", result.Errors.Select(x => x.Description)));
        }
    }
}
