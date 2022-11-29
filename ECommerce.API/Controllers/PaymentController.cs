using AutoMapper;
using ECommerce.Application.CQRS.Commands.CreatePayment;
using ECommerce.Application.CQRS.Querys.CalculatePayment;
using ECommerce.Application.Requests;
using ECommerce.Application.Responses.Payment;
using ECommerce.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PaymentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<BaseResponse> Create([FromBody] CreatePaymentRequest createPaymentRequest)
        {
            var calculate = await CalculatePayment(new() {BasketId = createPaymentRequest.BasketId, Discount = createPaymentRequest.Discount });
            var query = calculate.Response.Map(createPaymentRequest);
            var response = await _mediator.Send(query);

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = NoContent()
            };
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<BaseResponse<CalculatePaymentDto>> CalculatePayment([FromBody] CalculatePaymentRequest request)
        {
            var query = new CalculatePaymentQuery { BasketId = request.BasketId, Discount = request.Discount };
            var response = await _mediator.Send(query);
            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = response
            };
        }
    }
}
