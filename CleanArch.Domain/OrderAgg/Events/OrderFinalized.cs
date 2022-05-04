using CleanArch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.OrderAgg.Events
{
    public class OrderFinalized : BaseDomainEvent
    {
        public OrderFinalized(Guid userId, Guid productId)
        {
            UserId = userId;
            ProductId = productId;
        }

        public Guid UserId { get; private set; }
        public Guid ProductId { get; private set; }
    }
}
