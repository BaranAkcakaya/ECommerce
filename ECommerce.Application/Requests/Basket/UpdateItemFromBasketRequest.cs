using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Requests
{
    public class UpdateItemFromBasketRequest
    {
        public int BasketItemId { get; set; }
        public int Quantity { get; set; }
    }
}
