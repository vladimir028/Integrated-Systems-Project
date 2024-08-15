using Eshop.DomainEntities;
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
    public class ItineraryService : IItineraryService
    {
        private readonly IRepository<Itinerary> itineraryRepository;
        private readonly IRepository<TravelPackage> travelPackageRepository;

        public ItineraryService(IRepository<Itinerary> itineraryRepository, IRepository<TravelPackage> travelPackageRepository)
        {
            this.itineraryRepository = itineraryRepository;
            this.travelPackageRepository = travelPackageRepository;
        }

        public bool CreateNewItinerary(Itinerary i)
        {
            itineraryRepository.Insert(i);
            Itinerary itinerary = itineraryRepository.Get(i.Id);
            if (!itinerary.TravelPackage.AlreadyhasItinerary)
            {
                itinerary.TravelPackage.AlreadyhasItinerary = true;
                travelPackageRepository.Update(travelPackageRepository.Get(itinerary.TravelPackageId));
                return true;
            }
            itineraryRepository.Delete(itinerary);
            return false;
        }

        public void DeleteItinerary(Guid id)
        {
           itineraryRepository.Delete(itineraryRepository.Get(id)); 
        }

        public List<Itinerary> GetAllItineraries()
        {
           return itineraryRepository.GetAll().ToList();
        }

        public Itinerary GetDetailsForItinerary(Guid? id)
        {
            return itineraryRepository.Get(id);
        }

        public Itinerary GetItineratyForTravelPackage(Guid? id)
        {
            return itineraryRepository.GetAll().SingleOrDefault(s => s.TravelPackageId == id);
        }

        public void UpdateExistingItinerary(Itinerary i)
        {
           itineraryRepository.Update(i);
        }
    }
}
