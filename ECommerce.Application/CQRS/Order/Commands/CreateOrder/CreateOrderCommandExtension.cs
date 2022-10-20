using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;

namespace ECommerce.Application.CQRS.Commands.CreateOrder
{
    public static class CreateOrderCommandExtension
    {
        public static Order Map(this CreateOrderCommand request, double totalAmount)
        {
            return new()
            {
                Address = request.Address,
                BasketId = request.BasketId,
                TotalAmount = totalAmount,
                IsDeleted = false,
                CreateDate = DateTime.UtcNow,
                DeliveryStatus = DeliveryStatus.Preparing
            };
        }
    }
}
