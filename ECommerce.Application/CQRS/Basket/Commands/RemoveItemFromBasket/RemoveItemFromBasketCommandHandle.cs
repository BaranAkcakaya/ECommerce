using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Application.Repositories;
using ECommerce.Application.Responses;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.RemoveItemFromBasket
{
    public class RemoveItemFromBasketCommandHandle: IRequestHandler<RemoveItemFromBasketCommand, RemoveItemFromBasketDto>
    {
        private readonly IUnitOfWork<Basket> _unitOfWork;
        private readonly IBasketItemRepository _basketItemRepository;

        public RemoveItemFromBasketCommandHandle(IUnitOfWork<Basket> unitOfWork, IBasketItemRepository basketItemRepository)
        {
            _unitOfWork = unitOfWork;
            _basketItemRepository = basketItemRepository;
        }
        public async Task<RemoveItemFromBasketDto> Handle(RemoveItemFromBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _unitOfWork.BaseRepository.GetSingleAsync(p => p.Id == request.BasketId && p.IsDeleted == false);
            if (basket == null)
                throw new UserException("Bu kullanıcıya ait sepet bulunmuyor.");

            var basketItem = await _basketItemRepository.GetSingleAsync(bi => bi.BasketId == basket.Id && bi.Id == request.BasketItemId);
            if (basketItem == null)
                throw new BasketException("Bu sepette böyle bir ürün bulunmuyor.");

            _basketItemRepository.Remove(basketItem);
            await _unitOfWork.SaveChangesAsync();

            return new();
        }
    }
}
