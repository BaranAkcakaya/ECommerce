using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Requests
{
    public class AddItemToBasketRequest
    {
        public int BasketId { get; set; }
        public int ProductId { get; set; }
    }
}
