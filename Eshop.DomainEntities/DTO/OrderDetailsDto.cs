using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.DomainEntities.DTO
{
    public class OrderDetailsDto
    {
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? TravelPackageName { get; set; }
        public int TotalPrice { get; set; }
    }
}
