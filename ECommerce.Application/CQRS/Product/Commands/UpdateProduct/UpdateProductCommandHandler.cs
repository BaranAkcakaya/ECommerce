using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Application.Responses;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductDto>
    {
        private readonly IUnitOfWork<Product> _unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork<Product> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.BaseRepository.GetByIdAsync(request.Id);
            if (product == null)
                throw new ProductException("Böyle bir ürün yok.");

            product = request.Map(product);
            _unitOfWork.BaseRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();

            return new();
        }
    }
}
