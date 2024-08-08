using System.ComponentModel.DataAnnotations;

namespace Eshop.DomainEntities
{
    public class TravelPackageInOrders : BaseEntity
    {
        public Guid TravelPackageId { get; set; }
        public TravelPackage? TravelPackage { get; set; }

        public Guid OrderId { get; set; }
        public Order? UserOrder { get; set; }
        public int NumberOfTravelers { get; set; }
    }
}
