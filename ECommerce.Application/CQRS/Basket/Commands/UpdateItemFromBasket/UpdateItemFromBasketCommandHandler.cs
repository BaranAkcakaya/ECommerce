using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Application.Repositories;
using ECommerce.Application.Responses;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.UpdateItemFromBasket
{
    public class UpdateItemFromBasketCommandHandler : IRequestHandler<UpdateItemFromBasketCommand, UpdateItemFromBasketDto>
    {
        private readonly IUnitOfWork<Basket> _unitOfWork;
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IProductRepository _productRepository;

        public UpdateItemFromBasketCommandHandler(IUnitOfWork<Basket> unitOfWork, IBasketItemRepository basketItemRepository, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _basketItemRepository = basketItemRepository;
            _productRepository = productRepository;
        }
        public async Task<UpdateItemFromBasketDto> Handle(UpdateItemFromBasketCommand request, CancellationToken cancellationToken)
        {
            var basketItem = await _basketItemRepository.GetByIdAsync(request.BasketItemId);
            if (basketItem == null) 
                throw new BasketException("Böyle bir ürün bulunmuyor.");

            var product = await _productRepository.GetByIdAsync(basketItem.ProductId);
            if (request.Quantity > product.Stock)
                throw new ProductException("Ürün adeti yetersiz");

            basketItem.Quantity = request.Quantity;
            _basketItemRepository.Update(basketItem);
            await _unitOfWork.SaveChangesAsync();

            return new()
            {
                BasketItemId = basketItem.Id,
                Quantity = basketItem.Quantity,
                ProductId = basketItem.ProductId
            };
        }
    }
}
