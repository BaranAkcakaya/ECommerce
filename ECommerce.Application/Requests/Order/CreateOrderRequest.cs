using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Requests
{
    public class CreateOrderRequest
    {
        public string Address { get; set; }
        public int BasketId { get; set; }
    }
}
