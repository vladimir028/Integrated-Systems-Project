using Eshop.DomainEntities;
using Eshop.DomainEntities.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EshopWebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext<EshopApplicationUser>
    {
        public DbSet<TravelPackage> TravelPackages { get; set; }
        public DbSet<Agency> Agencies { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductsInShoppingCart> ProductsInShoppingCarts { get; set; }

        public DbSet<ProductsInOrders> ProductsInOrders { get; set; }
        public DbSet<EmailMessage> EmailMessages { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        { }

    }
}
