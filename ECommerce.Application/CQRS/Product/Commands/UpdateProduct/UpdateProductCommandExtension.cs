using ECommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.Commands.UpdateProduct
{
    public static class UpdateProductCommandExtension
    {
        public static Product Map(this UpdateProductCommand update, Product product)
        {
            product.Name = update.Name;
            product.Price = update.Price;
            product.Stock = update.Stock;
            product.Currency = update.Currency;

            return product;
        } 
    }
}
