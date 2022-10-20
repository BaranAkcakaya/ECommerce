using AutoMapper;
using ECommerce.Application.CQRS.Commands.CreateProduct;
using ECommerce.Application.CQRS.Commands.UpdateProduct;
using ECommerce.Application.Requests;

namespace ECommerce.Application.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<CreateProductRequest, CreateProductCommand>();
            CreateMap<UpdateProductRequest, UpdateProductCommand>();
        }
    }
}
