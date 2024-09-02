using Eshop.DomainEntities.PetAdoptionCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Service.PetAdoptionCenter.Interface
{
    public interface IPetsService
    {
        List<Pet> GetAllPets();
        void CreateNewPet(Pet pet);
        void DeletePet(Pet pet);
        void DeleteAllPetsFromDb();
    }
}
