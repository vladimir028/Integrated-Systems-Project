using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EshopWebApplication1.Data;
using Eshop.DomainEntities;
using System.Security.Claims;
using Eshop.Service.Interface;
using Eshop.DomainEntities.Domain;

namespace EshopWebApplication1.Controllers
{
    public class TravelPackagesController : Controller
    {
        private readonly ITravelPackageService _travelPackageService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IAgencyService _agencyService;

        public TravelPackagesController(ITravelPackageService? productService, 
            IShoppingCartService? shoppingCartService,
            IAgencyService agencyService)
        {
            _travelPackageService = productService;
            _shoppingCartService = shoppingCartService;
            _agencyService = agencyService;

        }

        // GET: TravelPackages
        public IActionResult Index()
        {
            return View(_travelPackageService.GetAllTravelPackages());
        }

        // GET: TravelPackages/Details/5
        public IActionResult Details(Guid? id)
        {
            var travelPackage = _travelPackageService.GetDetailsForTravelPackage(id); 
            return View(travelPackage);
        }

        // GET: TravelPackages/Create
        public IActionResult Create()
        {
            List<Agency> agencies = _agencyService.GetAllAgencies();
            ViewData["AgencyId"] = new SelectList(agencies, "Id", "Name");
            return View();
        }

        // POST: TravelPackages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TravelPackage travelPackage)
        {
            //if (!ModelState.IsValid)
            //{ 
            //    return View(travelPackage);
            //}
            _travelPackageService.CreateNewTravelPackage(travelPackage);
            
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddToCartConfirmed(TravelPackageInShoppingCart model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
            _shoppingCartService.AddToShoppingConfirmed(model, userId);
            return View("Index", _travelPackageService.GetAllTravelPackages());
        }

        public async Task<IActionResult> AddToCart(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var travelPackage = _travelPackageService.GetDetailsForTravelPackage(id);
            TravelPackageInShoppingCart ps = new TravelPackageInShoppingCart();
            ps.TravelPackageId = travelPackage.Id;
            return View(ps);
        }

        // GET: TravelPackages/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<Agency> agencies = _agencyService.GetAllAgencies();
            ViewData["AgencyId"] = new SelectList(agencies, "Id", "Name");
            var travelPackage =  _travelPackageService.GetDetailsForTravelPackage(id);
            if (travelPackage == null)
            {
                return NotFound();
            }
            return View(travelPackage);
        }

        // POST: TravelPackage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Price,Description,ImageTextBox,AgencyId")] TravelPackage travelPackage)
        {
            if (id != travelPackage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _travelPackageService.UpdeteExistingTravelPackage(travelPackage);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(travelPackage);
        }

        // GET: TravelPackage/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelPackage = _travelPackageService.GetDetailsForTravelPackage(id);
            if (travelPackage == null)
            {
                return NotFound();
            }

            return View(travelPackage);
        }

        // POST: TravelPackage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var travelPackage = _travelPackageService.GetDetailsForTravelPackage(id);
            if (travelPackage != null)
            {
                _travelPackageService.DeleteTravelPackage(id);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
