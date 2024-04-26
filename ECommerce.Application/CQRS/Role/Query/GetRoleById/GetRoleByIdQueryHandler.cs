using ECommerce.Application.Exceptions;
using ECommerce.Application.Responses.Role;
using ECommerce.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.Role.Query.GetRoleById
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, GetRoleByIdDto>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public GetRoleByIdQueryHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<GetRoleByIdDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());
            if (role == null)
                throw new RoleException("This Role Not Founded.");

            return new()
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}
