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
            if (i.StartDate.CompareTo(i.EndDate) >= 0) {
                return false;
            }
            List<Itinerary> itineraries =  itineraryRepository.GetAll().ToList();
            for(int j =0; j<itineraries.Count(); j++)
            {
                Itinerary itinerary = itineraries.ElementAt(j);
                if (itinerary.TravelPackageId.Equals(i.TravelPackageId)){
                    return false;
                }
            }
            TravelPackage travelPackage =  travelPackageRepository.Get(i.TravelPackageId);
            travelPackage.AlreadyhasItinerary = true;
            travelPackageRepository.Update(travelPackage);
            itineraryRepository.Insert(i);
            return true;


            //itineraryRepository.Insert(i);
            //Itinerary itinerary = itineraryRepository.Get(i.Id);
            //if (!itinerary.TravelPackage.AlreadyhasItinerary)
            //{
            //    itinerary.TravelPackage.AlreadyhasItinerary = true;
            //    travelPackageRepository.Update(travelPackageRepository.Get(itinerary.TravelPackageId));
            //    return true;
            //}
            //itineraryRepository.Delete(itinerary);
            //return false;
        }

        public void DeleteItinerary(Guid id)
        {
            Itinerary itinerary = itineraryRepository.Get(id);
            TravelPackage travelPackage = travelPackageRepository.Get(itinerary.TravelPackageId);
            if (travelPackage != null)
            {
                travelPackage.AlreadyhasItinerary = false;
                travelPackageRepository.Update(travelPackage);
            }
           itineraryRepository.Delete(itinerary); 
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
