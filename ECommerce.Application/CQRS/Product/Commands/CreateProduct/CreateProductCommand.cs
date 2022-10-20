using ECommerce.Application.Responses;
using ECommerce.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductDto>
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public Currency Currency { get; set; }
    }
}
