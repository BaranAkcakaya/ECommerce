using Azure;
using ECommerce.Application.CQRS.Role.Command.CreateRole;
using ECommerce.Application.CQRS.Role.Command.DeleteRole;
using ECommerce.Application.CQRS.Role.Command.UpdateRole;
using ECommerce.Application.CQRS.Role.Query.GetAllRoles;
using ECommerce.Application.CQRS.Role.Query.GetRoleById;
using ECommerce.Application.Requests.Role;
using ECommerce.Application.Responses.Role;
using ECommerce.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<BaseResponse> CreateRole([FromBody] CreateRoleRequest createRoleRequest)
        {
            var query = new CreateRoleCommand { RoleName = createRoleRequest.RoleName};
            var response = await _mediator.Send(query);

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = NoContent()
            };
        }

        [HttpDelete("{RoleId}")]
        public async Task<BaseResponse> DeleteRole([FromRoute] DeleteRoleRequest roleRequest)
        {
            var query = new DeleteRoleCommand { RoleId = roleRequest.RoleId };
            var response = await _mediator.Send(query);

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = NoContent()
            };
        }

        [HttpGet]
        public async Task<BaseResponse<List<GetAllRolesDto>>> GetAllRoles()
        {
            var response = await _mediator.Send(new GetAllRolesQuery());

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = response
            };
        }

        [HttpGet("{RoleId}")]
        public async Task<BaseResponse<GetRoleByIdDto>> GetRoleById([FromRoute] GetRoleByIdRequest getRoleById)
        {
            var query = new GetRoleByIdQuery { RoleId = getRoleById.RoleId };
            var response = await _mediator.Send(query);

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = response
            };
        }

        [HttpPut]
        public async Task<BaseResponse> UpdateRole([FromBody] UpdateRoleRequest updateRole)
        {
            var query = new UpdateRoleCommand { RoleId = updateRole.RoleId,  Name = updateRole.Name };
            var response = await _mediator.Send(query);

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = NoContent()
            };
        }
    }
}
