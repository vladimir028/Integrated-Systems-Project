using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.DomainEntities.Domain
{
    public class Activity : BaseEntity
    {
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }
        public string ThingsToDo { get; set; }
        public PlannedRoute PlannedRoute { get; set; }
        public Guid PlannedRouteId { get; set; }
    }
}
