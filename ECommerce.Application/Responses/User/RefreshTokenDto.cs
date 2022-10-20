using ECommerce.Application.Responses.Token;
using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Responses.User
{
    public class RefreshTokenDto
    {
        public TokenHandlerDto Token { get; set; }
    }
}
