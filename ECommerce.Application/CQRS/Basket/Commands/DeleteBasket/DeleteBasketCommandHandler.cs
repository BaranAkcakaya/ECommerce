using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Application.Repositories;
using ECommerce.Application.Responses;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Application.CQRS.Commands.DeleteBasket
{
    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand, DeleteBasketDto>
    {
        private readonly IUnitOfWork<Basket> _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly IBasketItemRepository _basketItemRepository;

        public DeleteBasketCommandHandler(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IUnitOfWork<Basket> unitOfWork, IBasketItemRepository basketItemRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _basketItemRepository = basketItemRepository;
        }
        public async Task<DeleteBasketDto> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            var userName = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            if (string.IsNullOrEmpty(userName))
                throw new UserNotFoundException();

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                throw new UserNotFoundException();

            var basket = await _unitOfWork.BaseRepository.GetSingleAsync(u => u.UserId == user.Id && u.IsDeleted == false);
            if (basket == null)
                throw new BasketException("Bu kişiye tanımlı Basket bulunmuyor.");

            var basketItem = _basketItemRepository.GetWhere(x => x.BasketId == basket.Id).ToList();
            if(basketItem != null)
                _basketItemRepository.RemoveRange(basketItem);

            basket.IsDeleted = true;
            _unitOfWork.BaseRepository.Update(basket);
            await _unitOfWork.SaveChangesAsync();

            return new();
        }
    }
}
