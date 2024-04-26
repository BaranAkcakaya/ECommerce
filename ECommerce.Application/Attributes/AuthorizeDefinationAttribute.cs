using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Attributes
{
    public class AuthorizeDefinationAttribute : Attribute
    {
        public string Menu { get; set; }
        public string? Defination { get; set; }
        public ActionType ActionType { get; set; }
    }
}
