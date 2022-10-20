using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Application.Repositories;
using ECommerce.Application.Responses;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.AddItemToBasket
{
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommand, AddItemToBasketDto>
    {
        private readonly IUnitOfWork<Basket> _unitOfWork;
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IProductRepository _productRepository;

        public AddItemToBasketCommandHandler(IUnitOfWork<Basket> unitOfWork, IBasketItemRepository basketItemRepository, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _basketItemRepository = basketItemRepository;
            _productRepository = productRepository;
        }
        public async Task<AddItemToBasketDto> Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _unitOfWork.BaseRepository.GetSingleAsync(p => p.Id == request.BasketId && p.IsDeleted == false);
            if (basket == null)
                throw new UserException("Bu kullanıcıya ait sepet bulunmuyor.");

            var _basketItem = await _basketItemRepository.GetSingleAsync(bi => bi.BasketId == basket.Id && bi.ProductId == request.ProductId);

            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null)
                throw new ProductException("Böyle bir ürün yok.");

            if (_basketItem != null && _basketItem.Quantity > product.Stock)
                throw new ProductException("Ürün adeti yetersiz");

            if (_basketItem != null)
                _basketItem.Quantity++;
            else
                await _basketItemRepository.AddAsync(new()
                {
                    ProductId = request.ProductId,
                    Quantity = 1,
                    BasketId = basket.Id
                });

            await _unitOfWork.SaveChangesAsync();

            return new();
        }
    }
}
