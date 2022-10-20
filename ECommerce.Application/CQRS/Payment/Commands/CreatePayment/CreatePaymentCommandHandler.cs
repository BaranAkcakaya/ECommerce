using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Application.Repositories;
using ECommerce.Application.Responses;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.CreatePayment
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommad, CreatePaymentDto>
    {
        private readonly IUnitOfWork<Payment> _unitOfWork;
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBasketItemRepository _basketItemRepository;

        public CreatePaymentCommandHandler(IUnitOfWork<Payment> unitOfWork, IBasketRepository basketRepository, IProductRepository productRepository, IBasketItemRepository basketItemRepository)
        {
            _unitOfWork = unitOfWork;
            _basketRepository = basketRepository;
            _productRepository = productRepository;
            _basketItemRepository = basketItemRepository;
        }

        public async Task<CreatePaymentDto> Handle(CreatePaymentCommad request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetByIdAsync(request.BasketId);
            if (basket == null)
                throw new BasketException("Böyle bir sepet yok.");

            var payment = await _unitOfWork.BaseRepository.GetSingleAsync(p => p.BasketId == request.BasketId);
            if (payment != null)
                throw new PaymentException("Bu ödeme zaten yapıldı.");

            await _unitOfWork.BaseRepository.AddAsync(request.Map());
            await DropoutOfStock(request.BasketId);
            await _unitOfWork.SaveChangesAsync();

            return new();
        }

        private async Task DropoutOfStock(int basketId)
        {
            var basketItems = _basketItemRepository.GetWhere(p => p.BasketId == basketId);
            if (basketItems == null)
                throw new BasketException("Sepette hiç ürün yok.");

            var products = await _productRepository.GetAll();
            foreach (var basketItem in basketItems)
            {
                var product = products.FirstOrDefault(p => p.Id == basketItem.ProductId);
                if (product == null || !products.Contains(product))
                    throw new ProductException("Sepette tanımlanmamış ürün bulunuyor.");

                product.Stock -= basketItem.Quantity;
                _productRepository.Update(product);
            }
        }
    }
}
