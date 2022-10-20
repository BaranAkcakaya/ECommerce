using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Enums
{
    public enum DeliveryStatus
    {
        Waiting = 1001,
        Preparing = 1002,
        Distributed = 1003,
        Delivered = 1004
    }
}
