using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.DomainEntities.PetAdoptionCenter
{
    public class PetAdoptionCenterUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Pet>? Pets { get; set; }
    }
}
