using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Application.Responses;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.DeleteProduct
{
    public class DeleteProductCommandHanler : IRequestHandler<DeleteProductCommand, DeleteProductDto>
    {
        private readonly IUnitOfWork<Product> _unitOfWork;

        public DeleteProductCommandHanler(IUnitOfWork<Product> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var product = await _unitOfWork.BaseRepository.GetByIdAsync(id);
            if (product == null)
                throw new ProductException("Böyle bir ürün yok.");

            await _unitOfWork.BaseRepository.Remove(id);
            await _unitOfWork.SaveChangesAsync();

            return new();
        }
    }
}
