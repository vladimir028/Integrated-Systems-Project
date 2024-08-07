using System.ComponentModel.DataAnnotations;

namespace Eshop.DomainEntities
{
    public class ProductsInShoppingCart : BaseEntity
    {
        public Guid ProductId { get; set; }
        public TravelPackage? Product { get; set; }

        public Guid ShoppingCartId { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
        public int Quantity { get; set; }
    }
}
