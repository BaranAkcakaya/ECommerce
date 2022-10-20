﻿using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Responses
{
    public class UpdateItemFromBasketDto
    {
        public int BasketItemId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
