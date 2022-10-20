using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Requests
{
    public class RemoveItemFromBasketRequest
    {
        public int BasketId { get; set; }
        public int BasketItemId { get; set; }
    }
}
