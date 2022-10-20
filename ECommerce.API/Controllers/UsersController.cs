using AutoMapper;
using ECommerce.Application.CQRS.User.Command.RefreshToken;
using ECommerce.Application.CQRS.User.Commands.CreateUser;
using ECommerce.Application.CQRS.User.Commands.LoginUser;
using ECommerce.Application.CQRS.User.Commands.ResertPasswordUser;
using ECommerce.Application.CQRS.User.Commands.UpdatePasswordUser;
using ECommerce.Application.Requests.User;
using ECommerce.Application.Responses.User;
using ECommerce.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<BaseResponse> Create([FromBody] CreateUserRequest createUserRequest)
        {
            var query = _mapper.Map<CreateUserCommand>(createUserRequest);
            var response = await _mediator.Send(query);

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = NoContent()
            };
        }

        [HttpPost("login")]
        public async Task<BaseResponse<LoginUserDto>> Login([FromBody] LoginUserRequest loginUserRequest)
        {
            var query = _mapper.Map<LoginUserCommand>(loginUserRequest);
            var response = await _mediator.Send(query);

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = response
            };
        }

        [HttpGet("login/refresToken")]
        public async Task<BaseResponse<RefreshTokenDto>> RefreshToken([FromQuery(Name = "rt")] string refreshToken)
        {
            var query = new RefreshTokenCommand { RefreshToken = refreshToken};
            var response = await _mediator.Send(query);

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = response
            };
        }

        [HttpPost("password/reset")]
        public async Task<BaseResponse<ResetPasswordUserDto>> ResetPassword([FromBody] ResertPasswordUserRequest resertPasswordUserRequest)
        {
            var query = new ResetPasswordUserCommand { Email = resertPasswordUserRequest.Email };
            var response = await _mediator.Send(query);

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = response
            };
        }

        [HttpPut("password/update")]
        public async Task<BaseResponse> UpdatePassword([FromBody] UpdatePasswordUserRequest updatePasswordUserRequest,
                                                        [FromQuery(Name = "i")] string id, 
                                                        [FromQuery(Name = "t")] string token)
        {
            var query = new UpdatePasswordUserCommand { Password = updatePasswordUserRequest.Password, UserId = id, Token = token };
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
