using Eshop.DomainEntities.PetAdoptionCenter;
using Eshop.Service.PetAdoptionCenter.Interface;
using EShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Service.PetAdoptionCenter.Implementation
{
    public class PetsService : IPetsService
    {
        private readonly IRepository<Pet> _petRepository;

        public PetsService(IRepository<Pet> petRepository)
        {
            _petRepository = petRepository;
        }

        public void CreateNewPet(Pet pet)
        {
            List<Pet> allPets = GetAllPets();
            foreach(Pet p in allPets)
            {
                if (p.Id.Equals(pet.Id))
                {
                    return;
                }
            }
            _petRepository.Insert(pet);
        }

        public void DeleteAllPetsFromDb()
        {
            List<Pet> allPets = _petRepository.GetAll().ToList();
            foreach (Pet pet in allPets) { 
                _petRepository.Delete(pet);
            }
            
        }

        public void DeletePet(Pet pet)
        {
            _petRepository.Delete(pet);
        }

        public List<Pet> GetAllPets()
        {
            return _petRepository.GetAll().ToList();
        }
    }
}
