using AutoMapper;
using ECommerce.Application.CQRS.Commands.CreateProduct;
using ECommerce.Application.CQRS.Commands.DeleteProduct;
using ECommerce.Application.CQRS.Commands.UpdateProduct;
using ECommerce.Application.CQRS.Queries.GetAllProduct;
using ECommerce.Application.CQRS.Queries.GetByIdProduct;
using ECommerce.Application.Requests;
using ECommerce.Application.Responses;
using ECommerce.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<BaseResponse<List<GetAllProductDto>>> GetAll([FromQuery] GetAllProductRequest getAllProduct)
        {
            var query = new GetAllProductQuery { Page = getAllProduct.Page, Size = getAllProduct.Size};
            var response = await _mediator.Send(query);

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = response
            };   
        }

        [HttpGet("{Id}")]
        public async Task<BaseResponse<GetByIdProductDto>> Get([FromRoute] GetByIdProductRequest getByIdProductRequest)
        {
            var query = new GetByIdProductQuery { Id = getByIdProductRequest.Id};
            var response = await _mediator.Send(query);
            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = response
            };
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<BaseResponse> Post([FromBody] CreateProductRequest product)
        {
            var query = _mapper.Map<CreateProductCommand>(product);
            var response = await _mediator.Send(query);

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = NoContent()
            };
        }

        [HttpDelete("{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<BaseResponse> Delete([FromRoute] DeleteProductRequest deleteProductRequest)
        {
            var query = new DeleteProductCommand { Id = deleteProductRequest.Id };
            await _mediator.Send(query);

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = NoContent()
            };
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<BaseResponse> Update([FromBody] UpdateProductRequest updateProductRequest)
        {
            var query = _mapper.Map<UpdateProductCommand>(updateProductRequest);
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
