using AutoMapper;
using ECommerce.Application.CQRS.Commands.CreateOrder;
using ECommerce.Application.Requests;
using ECommerce.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<BaseResponse> Create([FromBody]CreateOrderRequest createOrderRequest)
        {
            var query = _mapper.Map<CreateOrderCommand>(createOrderRequest);
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
