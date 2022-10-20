using ECommerce.Application.Exceptions;
using ECommerce.Application.Repositories;
using ECommerce.Application.Responses;
using MediatR;
using System.Net;

namespace ECommerce.Application.CQRS.Queries.GetByIdProduct
{
    public class GetByIdProductQueryHandle : IRequestHandler<GetByIdProductQuery, GetByIdProductDto>
    {
        private readonly IProductRepository _productReadRepository;
        public GetByIdProductQueryHandle(IProductRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetByIdProductDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetByIdAsync(request.Id);
            if (product == null)
                throw new ProductException("Böyle bir ürün bulunmuyor.");

            return product.Map();
        }
    }
}
