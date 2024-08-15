using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.DomainEntities.Domain
{
    public class Itinerary : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }   
        public TravelPackage TravelPackage { get; set; }   
        public Guid TravelPackageId { get; set; }
        public List<PlannedRoute> PlannedRoutes { get; set; }

        public Itinerary()
        {
            PlannedRoutes = new List<PlannedRoute>(getInitialSize());
        }

        public int getInitialSize()
        {
            return (EndDate.Date - StartDate.Date).Days;
        }

    }
}
