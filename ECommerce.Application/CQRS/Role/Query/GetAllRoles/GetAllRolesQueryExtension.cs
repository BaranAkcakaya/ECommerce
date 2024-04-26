using ECommerce.Application.Responses.Role;
using ECommerce.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.Role.Query.GetAllRoles
{
    public static class GetAllRolesQueryExtension
    {
        public static GetAllRolesDto Map(this AppRole appRole)
        {
            return new()
            {
                Id = appRole.Id,
                Name = appRole.Name
            };
        }
    }
}
