using ECommerce.Application.Responses.Role;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.Role.Command.CreateRole
{
    public class CreateRoleCommand : IRequest<CreateRoleDto>
    {
        public string RoleName { get; set; }
    }
}
