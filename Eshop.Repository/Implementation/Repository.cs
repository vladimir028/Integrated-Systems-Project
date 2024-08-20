using Eshop.DomainEntities;
using Eshop.DomainEntities.Domain;
using EShop.Repository.Interface;
using EshopWebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            if (typeof(T).IsAssignableFrom(typeof(TravelPackage))) {
                return entities.Include("Itinerary")
                     .Include("Itinerary.PlannedRoutes")
                     .Include("Itinerary.PlannedRoutes.Activities")
                     .Include("Agency").AsEnumerable();
            }
            if (typeof(T).IsAssignableFrom(typeof(PlannedRoute)))
            {
                return entities.Include("Itinerary")
                    .Include("Itinerary.TravelPackage").AsEnumerable();
            }
            if (typeof(T).IsAssignableFrom(typeof(Itinerary)))
            {
                return entities.Include("TravelPackage").Include("PlannedRoutes")
                    .Include("PlannedRoutes.Activities").AsEnumerable();
            }
            if (typeof(T).IsAssignableFrom(typeof(Order)))
            {
                return entities
                    .Include("TravelPackageInOrders")
                    .Include("TravelPackageInOrders.TravelPackage.Itinerary")
                    .Include("TravelPackageInOrders.TravelPackage.Itinerary.PlannedRoutes")
                    .Include("TravelPackageInOrders.TravelPackage.Itinerary.PlannedRoutes.Activities")
                    .AsEnumerable();
            }
            return entities.AsEnumerable();
        }

        public T Get(Guid? id)
        {
            if (typeof(T).IsAssignableFrom(typeof(TravelPackage)))
            {
                return entities.Include("Itinerary")
                     .Include("Itinerary.PlannedRoutes")
                     .Include("Itinerary.PlannedRoutes.Activities")
                     .Include("Agency").SingleOrDefault(s => s.Id == id);
            }
            if (typeof(T).IsAssignableFrom(typeof(PlannedRoute)))
            {
                return entities.Include("Itinerary")
                    .Include("Itinerary.TravelPackage")
                    .Include("Activities")
                    .SingleOrDefault(s => s.Id == id);
            }
            if (typeof(T).IsAssignableFrom(typeof(Itinerary)))
            {
                return entities.Include("TravelPackage")
                    .Include("PlannedRoutes")
                    .Include("PlannedRoutes.Activities")
                    .SingleOrDefault(s => s.Id == id);
            }
            if (typeof(T).IsAssignableFrom(typeof(Order)))
            {
                return entities
                    .Include("TravelPackageInOrders")
                    .Include("TravelPackageInOrders.TravelPackage")
                    .SingleOrDefault(s => s.Id == id);
            }
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
