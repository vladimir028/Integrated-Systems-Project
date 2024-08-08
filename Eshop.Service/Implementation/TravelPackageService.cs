using Eshop.DomainEntities;
using Eshop.Repository.Interface;
using EShop.Repository.Interface;
using Eshop.Service.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Eshop.DomainEntities.Domain;

namespace Eshop.Service.Implementation
{
    public class TravelPackageService : ITravelPackageService
    {
        private readonly IRepository<TravelPackage> _travelPackageRepository;
        private readonly IRepository<TravelPackageInShoppingCart> _productInShoppingCartRepository;
        private readonly IRepository<Agency> _agencyRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<TravelPackageService> _logger;
        public TravelPackageService(IRepository<Agency> agencyRepository, IRepository<TravelPackage> travelPackageRepository, ILogger<TravelPackageService> logger, IRepository<TravelPackageInShoppingCart> productInShoppingCartRepository, IUserRepository userRepository)
        {
            _travelPackageRepository = travelPackageRepository;
            _userRepository = userRepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
            _agencyRepository = agencyRepository;
            _logger = logger;
        }

        public void CreateNewTravelPackage(TravelPackage travelPackage)
        {
            List<String> images = travelPackage.ImageTextBox.Split(",").ToList();
            travelPackage.Images = images;
            _travelPackageRepository.Insert(travelPackage);
            
        }

        public void DeleteTravelPackage(Guid id)
        {
            var product = _travelPackageRepository.Get(id);
            _travelPackageRepository.Delete(product);
        }

        public List<TravelPackage> GetAllTravelPackages()
        {
            return _travelPackageRepository.GetAll().ToList();
        }

        public TravelPackage GetDetailsForTravelPackage(Guid? id)
        {
            return _travelPackageRepository.Get(id);
        }

        public void UpdeteExistingTravelPackage(TravelPackage travelPackage)
        {
            List<String> images = travelPackage.ImageTextBox.Split(",").ToList();
            travelPackage.Images = images;
            _travelPackageRepository.Update(travelPackage);
        }
    }
}
