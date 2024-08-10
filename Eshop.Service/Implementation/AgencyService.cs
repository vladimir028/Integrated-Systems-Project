using Eshop.DomainEntities.Domain;
using Eshop.Service.Interface;
using EShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Service.Implementation
{
    public class AgencyService : IAgencyService
    {
        private readonly IRepository<Agency> agencyRepository;

        public AgencyService(IRepository<Agency> agencyRepository)
        {
            this.agencyRepository = agencyRepository;
        }

        public void CreateNewAgency(Agency p)
        {
            agencyRepository.Insert(p);
        }

        public void DeleteAgency(Guid id)
        {
           agencyRepository.Delete(agencyRepository.Get(id));
        }

        public List<Agency> GetAllAgencies()
        {
           return agencyRepository.GetAll().ToList();
        }

        public Agency GetDetailsForAgency(Guid? id)
        {
            return agencyRepository.Get(id);
        }

        public void UpdateExistingAgency(Agency p)
        {
           agencyRepository.Update(p);
        }
    }
}
