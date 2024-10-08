﻿namespace Eshop.DomainEntities
{
    public class ShoppingCart : BaseEntity
    {

        public Guid EshopApplicationUserId { get; set; }
        public virtual List<TravelPackageInShoppingCart>? TravelPackagesInShoppingCarts { get; set; }
    }
}
