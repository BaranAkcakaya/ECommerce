using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Requests
{
    public class CreatePaymentRequest
    {
        public string CartNumber { get; set; }
        public string NameOnCard { get; set; }
        public PaymentOption PaymentOption { get; set; }
        public int BasketId { get; set; }
    }
}
