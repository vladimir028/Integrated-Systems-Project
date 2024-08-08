using Eshop.DomainEntities;

namespace Eshop.DomainEntities
{
    public class ShoppingCartDto
    {
        public List<TravelPackageInShoppingCart>? ProductsInShoppingCarts { get; set; }
        public double TotalPrice { get; set; }
    }
}
