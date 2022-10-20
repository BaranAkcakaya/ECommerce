using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Application.Repositories;
using ECommerce.Application.Responses;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Application.CQRS.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderDto>
    {
        private readonly IUnitOfWork<Order> _unitOfWork;
        private readonly IBasketRepository _basketRepository;
        private readonly IPaymentRepository _paymentRepository;

        public CreateOrderCommandHandler(IUnitOfWork<Order> unitOfWork, IBasketRepository basketRepository, IPaymentRepository paymentRepository)
        {
            _unitOfWork = unitOfWork;
            _basketRepository = basketRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<CreateOrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetSingleAsync(p => p.Id == request.BasketId && p.IsDeleted == false);
            if (basket == null)
                throw new BasketException("Böyle bir sepet bulunmuyor.");

            var payment = await _paymentRepository.GetSingleAsync(p => p.BasketId == request.BasketId);
            if (payment == null)
                throw new PaymentException("Bu Sepete ait ödeme bulunmuyor.");

            await _unitOfWork.BaseRepository.AddAsync(request.Map(payment.Amount));
            await _unitOfWork.SaveChangesAsync();

            return new();
        }
    }
}
