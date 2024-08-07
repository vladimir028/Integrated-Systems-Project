using Eshop.DomainEntities;
using Eshop.DomainEntities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Service.Interface
{
    public interface IAgencyService
    {
        List<Agency> GetAllAgencies();
        Agency GetDetailsForAgency(Guid? id);
        void CreateNewAgency(Agency p);
        void UpdeteExistingAgency(Agency p);
        void DeleteAgency(Guid id);
    }
}
