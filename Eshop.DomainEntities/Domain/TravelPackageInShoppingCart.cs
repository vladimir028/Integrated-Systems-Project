using System.ComponentModel.DataAnnotations;

namespace Eshop.DomainEntities
{
    public class TravelPackageInShoppingCart : BaseEntity
    {
        public Guid TravelPackageId { get; set; }
        public TravelPackage? TravelPackage { get; set; }

        public Guid ShoppingCartId { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
        public int NumberOfTravelers { get; set; }
    }
}
