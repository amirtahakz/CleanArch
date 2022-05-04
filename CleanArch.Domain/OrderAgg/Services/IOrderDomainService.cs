using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.OrderAgg.Services
{
    public interface IOrderDomainService
    {
        bool IsProductExist(Guid productId);
    }
}
