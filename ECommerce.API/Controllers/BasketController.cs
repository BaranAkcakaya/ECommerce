using ECommerce.Application.Attributes;
using ECommerce.Application.Const;
using ECommerce.Application.CQRS.Commands.AddItemToBasket;
using ECommerce.Application.CQRS.Commands.CreateBasket;
using ECommerce.Application.CQRS.Commands.DeleteBasket;
using ECommerce.Application.CQRS.Commands.RemoveItemFromBasket;
using ECommerce.Application.CQRS.Commands.UpdateItemFromBasket;
using ECommerce.Application.CQRS.Querys.GetBasketItems;
using ECommerce.Application.CQRS.Querys.GetBasketItemsFromUserId;
using ECommerce.Application.Requests;
using ECommerce.Application.Responses;
using ECommerce.Domain.Common;
using ECommerce.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Yeni Sepet Oluşturur.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthorizeDefination(Menu = AuthorizeDefinationConst.Baskets, ActionType = ActionType.Writing, Defination = "Create Basket.")]
        public async Task<BaseResponse<CreateBasketDto>> CreateBasket()
        {
            var query = new CreateBasketCommand();
            var response = await _mediator.Send(query);

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = response
            };
        }

        /// <summary>
        /// Sepetteki Ürünleri Getirir
        /// </summary>
        /// <param name="basketItemsRequest"></param>
        /// <returns></returns>
        [HttpGet("{BasketId}")]
        [AuthorizeDefination(Menu = AuthorizeDefinationConst.Baskets, ActionType = ActionType.Reading)]
        public async Task<BaseResponse<List<GetBasketItemsDto>>> GetBasketItems([FromRoute]GetBasketItemsRequest basketItemsRequest)
        {
            var query = new GetBasketItemsQuery { BasketId = basketItemsRequest.BasketId};
            var response = await _mediator.Send(query);

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = response
            };
        }

        /// <summary>
        /// Sepetteki Ürünleri Kullanıcı Id'sine göre getirir
        /// </summary>
        /// <param name="addItem"></param>
        /// <returns></returns>
        [HttpGet]
        [AuthorizeDefination(Menu = AuthorizeDefinationConst.Baskets, ActionType = ActionType.Reading)]
        public async Task<BaseResponse<List<GetBasketItemsDto>>> GetBasketItemsFromUserId([FromQuery(Name = "ui")] int id)
        {
            var query = new GetBasketItemsFromUserIdQuery { UserId = id };
            var response = await _mediator.Send(query);

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = response
            };
        }

        /// <summary>
        /// Sepete Ürün Ekler
        /// </summary>
        /// <param name="addItem"></param>
        /// <returns></returns>
        [HttpPost("item/add")]
        [AuthorizeDefination(Menu = AuthorizeDefinationConst.Baskets, ActionType = ActionType.Writing)]
        public async Task<BaseResponse> AddItemToBasket([FromBody]AddItemToBasketRequest addItem)
        {
            var query = new AddItemToBasketCommand {BasketId = addItem.BasketId, ProductId = addItem.ProductId};
            var response = await _mediator.Send(query);

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = NoContent()
            };
        }

        /// <summary>
        /// Sepetteki Ürünü Günceller
        /// </summary>
        /// <param name="updateItem"></param>
        /// <returns></returns>
        [HttpPut("item/update")]
        [AuthorizeDefination(Menu = AuthorizeDefinationConst.Baskets, ActionType = ActionType.Updating)]
        public async Task<BaseResponse<UpdateItemFromBasketDto>> UpdateItemFromBasket(UpdateItemFromBasketRequest updateItem)
        {
            var query = new UpdateItemFromBasketCommand { BasketItemId = updateItem.BasketItemId, Quantity = updateItem.Quantity };
            var response = await _mediator.Send(query);

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = response
            };
        }

        /// <summary>
        /// Sepeti Siler
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [AuthorizeDefination(Menu = AuthorizeDefinationConst.Baskets, ActionType = ActionType.Deleting)]
        public async Task<BaseResponse> DeleteBasket()
        {
            var query = new DeleteBasketCommand();
            var response = await _mediator.Send(query);

            return new()
            {
                Success = true,
                ErrorMessage = null,
                Response = NoContent()
            };
        }

        /// <summary>
        /// Sepetteki Ürünü Siler
        /// </summary>
        /// <param name="removeItem"></param>
        /// <returns></returns>
        [HttpDelete("item/delete")]
        [AuthorizeDefination(Menu = AuthorizeDefinationConst.Baskets, ActionType = ActionType.Deleting)]
        public async Task<BaseResponse> RemoveItemFromBasket(RemoveItemFromBasketRequest removeItem)
        {
            var query = new RemoveItemFromBasketCommand { BasketItemId = removeItem.BasketItemId, BasketId = removeItem.BasketId};
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
