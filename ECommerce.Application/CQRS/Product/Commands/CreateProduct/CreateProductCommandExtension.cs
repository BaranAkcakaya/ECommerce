using ECommerce.Domain.Entities;

namespace ECommerce.Application.CQRS.Commands.CreateProduct
{
    public static class CreateProductCommandExtension
    {
        public static Product Map(this CreateProductCommand createProduct)
        {
            return new()
            {
                Name = createProduct.Name,
                Price = createProduct.Price,
                Stock = createProduct.Stock,
                Currency = createProduct.Currency,
                IsDeleted = false
            };
        }
    }
}
