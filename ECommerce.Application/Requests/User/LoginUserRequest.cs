using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Requests.User
{
    public class LoginUserRequest
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
