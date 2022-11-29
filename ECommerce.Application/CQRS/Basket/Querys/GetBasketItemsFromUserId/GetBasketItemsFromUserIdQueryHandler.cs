using ECommerce.Application.CQRS.Querys.GetBasketItems;
using ECommerce.Application.CQRS.Querys.GetBasketItemsFromUserId;
using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Application.Repositories;
using ECommerce.Application.Responses;
using ECommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.Querys.GetBasketItemsFromUserId
{
    public class GetBasketItemsFromUserIdQueryHandler : IRequestHandler<GetBasketItemsFromUserIdQuery, List<GetBasketItemsDto>>
    {
        private readonly IUnitOfWork<Basket> _unitOfWork;
        private readonly IBasketItemRepository _basketItemRepository;

        public GetBasketItemsFromUserIdQueryHandler(IUnitOfWork<Basket> unitOfWork, IBasketItemRepository basketItemRepository)
        {
            _unitOfWork = unitOfWork;
            _basketItemRepository = basketItemRepository;
        }
        public async Task<List<GetBasketItemsDto>> Handle(GetBasketItemsFromUserIdQuery request, CancellationToken cancellationToken)
        {
            var basket = await _unitOfWork.BaseRepository.GetByIdAsync(request.UserId);
            if (basket == null)
                throw new UserException("Bu kullanıcıya ait sepet bulunmuyor.");

            var basketItems = _basketItemRepository.GetWhere(b => b.BasketId == basket.Id).ToList();

            return basketItems.Select(x => x.Map()).ToList();
        }
    }
}
