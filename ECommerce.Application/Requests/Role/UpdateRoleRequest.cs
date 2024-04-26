using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Requests.Role
{
    public class UpdateRoleRequest
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}
