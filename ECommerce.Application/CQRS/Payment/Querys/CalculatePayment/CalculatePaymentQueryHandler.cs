using ECommerce.Application.Exceptions;
using ECommerce.Application.Repositories;
using ECommerce.Application.Responses.Payment;
using MediatR;

namespace ECommerce.Application.CQRS.Querys.CalculatePayment
{
    public class CalculatePaymentQueryHandler : IRequestHandler<CalculatePaymentQuery, CalculatePaymentDto>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IProductRepository _productRepository;

        public CalculatePaymentQueryHandler(IBasketRepository basketRepository, IBasketItemRepository basketItemRepository, IProductRepository productRepository)
        {
            _basketRepository = basketRepository;
            _basketItemRepository = basketItemRepository;
            _productRepository = productRepository;
        }

        public async Task<CalculatePaymentDto> Handle(CalculatePaymentQuery request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetSingleAsync(p => p.Id == request.BasketId && p.IsDeleted == false );
            if (basket == null)
                throw new BasketException("Böyle bir sepet tanımlı değil.");

            var amount = 0.0;
            var discountAmount = 0.0;
            var basketItems = _basketItemRepository.GetWhere(p => p.BasketId == request.BasketId);
            if (basketItems == null)
                return request.Map(amount, discountAmount);

            var products = await _productRepository.GetAll();
            foreach(var basketItem in basketItems)
            {
                var product = products.FirstOrDefault(p => p.Id == basketItem.ProductId);
                if (product == null || !products.Contains(product))
                    throw new ProductException("Sepette tanımlanmamış ürün bulunuyor.");

                amount += product.Price * basketItem.Quantity;
            }

            discountAmount = (amount*request.Discount/100);
            amount -= discountAmount;

            return request.Map(amount, discountAmount);


        }
    }
}
