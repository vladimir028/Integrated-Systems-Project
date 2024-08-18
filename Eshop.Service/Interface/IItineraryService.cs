using Eshop.DomainEntities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Service.Interface
{
    public interface IItineraryService
    {
        List<Itinerary> GetAllItineraries();
        Itinerary GetDetailsForItinerary(Guid? id);
        bool CreateNewItinerary(Itinerary i);
        void UpdateExistingItinerary(Itinerary i);
        void DeleteItinerary(Guid id);
        //TravelPackageId
        Itinerary GetItineratyForTravelPackage(Guid? id);
    }
}
