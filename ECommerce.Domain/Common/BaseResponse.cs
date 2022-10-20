using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Common
{
    public class BaseResponse<TResponse>
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public TResponse? Response { get; set; }

    }

    public class BaseResponse
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public object? Response { get; set; }

    }
}
