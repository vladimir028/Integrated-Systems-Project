using Eshop.DomainEntities.Domain;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Eshop.DomainEntities
{
    public class TravelPackage : BaseEntity
    {
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public List<String>? Images { get; set; }
        public string? ImageTextBox {  get; set; }
        public virtual Agency? Agency { get; set; }
        public Guid AgencyId { get; set; }
        public bool AlreadyhasItinerary { get; set; } = false;
        public Itinerary Itinerary { get; set; }

    }
}
