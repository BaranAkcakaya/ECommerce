using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Exceptions
{
    public class ProductException : Exception
    {
        public ProductException(string? message) : base(message)
        {
        }
    }
}
