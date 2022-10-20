using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Requests
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public Currency Currency { get; set; }
    }
}
