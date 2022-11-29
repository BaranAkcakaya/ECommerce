using ECommerce.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.CQRS.Querys.GetBasketItemsFromUserId
{
    public class GetBasketItemsFromUserIdQuery : IRequest<List<GetBasketItemsDto>>
    {
        public int UserId { get; set; }
    }
}
