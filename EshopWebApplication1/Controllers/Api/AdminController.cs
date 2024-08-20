using Eshop.DomainEntities;
using Eshop.DomainEntities.Domain;
using Eshop.DomainEntities.DTO;
using Eshop.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EshopWebApplication1.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly ITravelPackageService _packageService;

        private readonly IUserService userService;

        private readonly IOrderService orderService;

        private readonly IItineraryService itineraryService;

        public AdminController(ITravelPackageService packageService, IUserService userService, IOrderService orderService, IItineraryService itineraryService)
        {
            _packageService = packageService;
            this.userService = userService;
            this.orderService = orderService;
            this.itineraryService = itineraryService;
        }

        [HttpGet("[action]")]
        public List<TravelPackage> GetAllTravelPackages()
        {
            return this._packageService.GetAllTravelPackages();
        }

        [HttpGet("[action]")]
        public List<EshopApplicationUser> GetAllUsers()
        {
            return this.userService.GetAllUsers().ToList();
        }

        [HttpGet("[action]")]
        public List<OrderDetailsDto> GetAllOrders()
        {
            return this.orderService.GetAllOrderDetails().ToList();
        }

        [HttpGet("[action]")]
        public List<Itinerary> GetAllItineraries()
        {
            return this.itineraryService.GetAllItineraries().ToList();
        }
    }
}
