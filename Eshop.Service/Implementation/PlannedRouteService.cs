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
    public class PlannedRouteService : IPlannedRouteService
    {
        private readonly IRepository<PlannedRoute> plannedRouteRepository;

        public PlannedRouteService(IRepository<PlannedRoute> plannedRouteRepository)
        {
            this.plannedRouteRepository = plannedRouteRepository;
        }

        public void CreateNewPlanningRoute(PlannedRoute pr)
        {
            plannedRouteRepository.Insert(pr);
        }

        public void DeletePlanningRoute(Guid pr)
        {
           plannedRouteRepository.Delete(plannedRouteRepository.Get(pr));
        }

        public List<PlannedRoute> GetAllPlanningRoutes()
        {
            return plannedRouteRepository.GetAll().ToList();
        }

        public PlannedRoute GetDetailsForPlanningRoute(Guid? id)
        {
            return plannedRouteRepository.Get(id);
        }

        //itinerartyID
        public PlannedRoute getPlanningRouteForItineraty(Guid id)
        {
            return plannedRouteRepository.GetAll()
                .SingleOrDefault(s => s.ItineraryId == id);
        }

        public void UpdateExistingPlanningRoute(PlannedRoute pr)
        {
            plannedRouteRepository.Update(pr);
        }
    }
}
