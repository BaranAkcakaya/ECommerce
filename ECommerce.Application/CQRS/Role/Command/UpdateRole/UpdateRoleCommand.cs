using ECommerce.Application.Responses.Role;
using MediatR;

namespace ECommerce.Application.CQRS.Role.Command.UpdateRole
{
    public class UpdateRoleCommand : IRequest<UpdateRoleDto>
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}
