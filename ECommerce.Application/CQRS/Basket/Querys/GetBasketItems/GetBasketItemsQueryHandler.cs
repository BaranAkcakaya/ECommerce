using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Application.Repositories;
using ECommerce.Application.Responses;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.CQRS.Querys.GetBasketItems
{
    public class GetBasketItemsQueryHandler : IRequestHandler<GetBasketItemsQuery, List<GetBasketItemsDto>>
    {
        private readonly IUnitOfWork<Basket> _unitOfWork;
        private readonly IBasketItemRepository _basketItemRepository;

        public GetBasketItemsQueryHandler(IUnitOfWork<Basket> unitOfWork, IBasketItemRepository basketItemRepository)
        {
            _unitOfWork = unitOfWork;
            _basketItemRepository = basketItemRepository;
        }

        public async Task<List<GetBasketItemsDto>> Handle(GetBasketItemsQuery request, CancellationToken cancellationToken)
        {
            var basket = await _unitOfWork.BaseRepository.GetSingleAsync(p => p.Id == request.BasketId && p.IsDeleted == false);
            if (basket == null)
                throw new UserException("Bu kullanıcıya ait sepet bulunmuyor.");

            var basketItems = _basketItemRepository.GetWhere(b => b.BasketId == basket.Id).ToList();

            return basketItems.Select(x => x.Map()).ToList();
        }
    }
}
