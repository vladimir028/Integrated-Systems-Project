using Eshop.DomainEntities;
using Eshop.DomainEntities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Service.Interface
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrderDetails();
        Order GetDetailsForOrder(BaseEntity model);
    }
}
