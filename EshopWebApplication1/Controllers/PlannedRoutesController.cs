using Eshop.DomainEntities.Domain;
using Eshop.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EshopWebApplication1.Controllers
{
    public class PlannedRoutesController : Controller
    {
       private readonly IPlannedRouteService plannedRouteService;
        private readonly IItineraryService itineraryService;

        public PlannedRoutesController(IPlannedRouteService plannedRouteService, IItineraryService itineraryService)
        {
            this.plannedRouteService = plannedRouteService;
            this.itineraryService = itineraryService;
        }

        // GET: PlanningRoutes
        public IActionResult Index()
        {
            return View(plannedRouteService.GetAllPlanningRoutes());
        }

        // GET: plannedRoute/Details/Id
        public IActionResult Details(Guid? id)
        {
            var route = plannedRouteService.GetDetailsForPlanningRoute(id);
            return View(route);
        }

        // GET: Agencies/Create/3
        //Path Variable Id is from the Itinerary!!
        public IActionResult Create(Guid? id)
        {
            Itinerary itinerary = itineraryService.GetDetailsForItinerary(id);
            ViewBag.ItineraryId = id;
            ViewBag.Count = itinerary.getInitialSize();
            var model = new List<PlannedRoute>();
            for (int i = 0; i < ViewBag.Count; i++)
            {
                PlannedRoute plannedRoute = new PlannedRoute();
                plannedRoute.Activities = new List<Activity>(5);
                for (int j = 0; j < 5; j++)
                {
                    Activity activity = new Activity();
                    plannedRoute.Activities.Add(activity);
                }
                model.Add(plannedRoute);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(List<PlannedRoute> planningRoutes)
        {

            foreach (var route in planningRoutes)
            {
                plannedRouteService.CreateNewPlanningRoute(route);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: plannedRoute/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var route = plannedRouteService.GetDetailsForPlanningRoute(id);
            if (route == null)
            {
                return NotFound();
            }
            return View(route);
        }

        // POST: plannedRoute/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Email,Phone,Address")] PlannedRoute plannedRoute)
        {
            if (id != plannedRoute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    plannedRouteService.UpdateExistingPlanningRoute(plannedRoute);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(plannedRoute);
        }

        // GET: PlannedRoute/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agency = plannedRouteService.GetDetailsForPlanningRoute(id);
            if (agency == null)
            {
                return NotFound();
            }

            return View(agency);
        }

        // POST: PlannedRoute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var plannedRoute = plannedRouteService.GetDetailsForPlanningRoute(id);
            if (plannedRoute != null)
            {
                plannedRouteService.DeletePlanningRoute(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
