using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ECommerce.Application.Exceptions
{
    public class RoleException : Exception
    {
        public RoleException()
        {
        }

        public RoleException(string message, HttpStatusCode statusCode)
        {
            var exceptionMessage = new HttpResponseMessage(statusCode)
            {
                ReasonPhrase = message
            };
            throw new HttpResponseException(exceptionMessage);
        }

        public RoleException(string? message) : base(message)
        {
        }
    }
}
