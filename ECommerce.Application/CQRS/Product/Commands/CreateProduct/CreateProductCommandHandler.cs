using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Application.Responses;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductDto>
    {
        private IUnitOfWork<Product> _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork<Product> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var parameter = request.Map();
            await _unitOfWork.BaseRepository.AddAsync(parameter);
            await _unitOfWork.SaveChangesAsync();

            return new();
        }
    }
}
