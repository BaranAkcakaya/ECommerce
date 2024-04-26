using ECommerce.Application.Responses.Role;
using ECommerce.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.Role.Query.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<GetAllRolesDto>>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public GetAllRolesQueryHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<GetAllRolesDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles =  _roleManager.Roles;
            return roles.Select(x => x.Map()).ToList(); ;
        }
    }
}
