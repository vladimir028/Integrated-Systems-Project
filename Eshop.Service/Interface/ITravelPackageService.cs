using Eshop.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Service.Interface
{
    public interface ITravelPackageService
    {
        List<TravelPackage> GetAllTravelPackages();
        TravelPackage GetDetailsForTravelPackage(Guid? id);
        void CreateNewTravelPackage(TravelPackage p);
        void UpdeteExistingTravelPackage(TravelPackage p);
        void DeleteTravelPackage(Guid id);
    }
}
