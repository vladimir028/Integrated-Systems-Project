using Eshop.DomainEntities.PetAdoptionCenter;
using Eshop.Service.PetAdoptionCenter.Interface;
using Microsoft.AspNetCore.Mvc;



namespace EshopWebApplication1.Controllers.PetAdoptionCenter
{
    public class PetsController : Controller
    {
        private readonly IPetsService petsService;

        public PetsController(IPetsService petsService)
        {
            this.petsService = petsService;
        }

        public IActionResult Index()
        {

            HttpClient client = new HttpClient();

            string URL = "https://petadoptioncenterapplication.azurewebsites.net/api/PacAdmin/ListAllPets";

            HttpResponseMessage response = client.GetAsync(URL).Result;

            var data = response.Content.ReadAsAsync<List<Pet>>().Result;
            for (int i = 0; i < data.Count(); i++)
            {
                Pet pet = data[i];
                petsService.CreateNewPet(pet);

            }
            List<Pet> allPets = petsService.GetAllPets();
            return View(allPets);
        }
    }
}
