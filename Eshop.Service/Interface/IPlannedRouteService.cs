using Eshop.DomainEntities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Service.Interface
{
    public interface IPlannedRouteService
    {
        List<PlannedRoute> GetAllPlanningRoutes();
        PlannedRoute GetDetailsForPlanningRoute(Guid? id);
        void CreateNewPlanningRoute(PlannedRoute pr);
        void UpdateExistingPlanningRoute(PlannedRoute pr);
        void DeletePlanningRoute(Guid id);
        //itinerartyID
        PlannedRoute getPlanningRouteForItineraty(Guid id);
    }
}
