using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Application.Responses;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Application.CQRS.Commands.CreateBasket
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, CreateBasketDto>
    {
        private readonly IUnitOfWork<Basket> _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public CreateBasketCommandHandler(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IUnitOfWork<Basket> unitOfWork )
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateBasketDto> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            var userName = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
                throw new UserNotFoundException();
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
                throw new UserNotFoundException();

            var basket = await _unitOfWork.BaseRepository.GetSingleAsync(u => u.UserId == user.Id && u.IsDeleted == false);

            Basket? returnBasket = null;
            if (basket == null)
            {
                var parameter = new Basket { UserId = user.Id };
                await _unitOfWork.BaseRepository.AddAsync(parameter);
                await _unitOfWork.SaveChangesAsync();
                returnBasket = await _unitOfWork.BaseRepository.GetSingleAsync(p => p.UserId == user.Id);
            }
            else
                returnBasket = basket;

            return new()
            {
                UserId = returnBasket.UserId,
                BasketId = returnBasket.Id
            };
        }
    }
}
