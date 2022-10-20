using ECommerce.Application.Repositories;
using ECommerce.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECommerce.Application.CQRS.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<GetAllProductDto>>
    {
        readonly IProductRepository _productReadRepository;
        private readonly ILogger<GetAllProductQueryHandler> _logger;

        public GetAllProductQueryHandler(IProductRepository productReadRepository, ILogger<GetAllProductQueryHandler> logger)
        {
            _productReadRepository = productReadRepository;
            _logger = logger;
        }

        public async Task<List<GetAllProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productReadRepository.GetAll();
            _logger.LogInformation("Tüm ürünler getirildi.");
            return products.Select(x => x.Map()).ToList();
        }
    }
}
