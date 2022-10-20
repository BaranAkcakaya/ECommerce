using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Exceptions
{
    internal class BasketException : Exception
    {
        public BasketException(string? message) : base(message)
        {
        }
    }
}
