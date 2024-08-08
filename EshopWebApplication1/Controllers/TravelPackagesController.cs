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

        // GET: Products
        public IActionResult Index()
        {
            return View(_travelPackageService.GetAllTravelPackages());
        }

        // GET: Products/Details/5
        public IActionResult Details(Guid? id)
        {
            var product = _travelPackageService.GetDetailsForTravelPackage(id); 
            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            List<Agency> agencies = _agencyService.GetAllAgencies();
            ViewData["AgencyId"] = new SelectList(agencies, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<Agency> agencies = _agencyService.GetAllAgencies();
            ViewData["AgencyId"] = new SelectList(agencies, "Id", "Name");
            var product =  _travelPackageService.GetDetailsForTravelPackage(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _travelPackageService.GetDetailsForTravelPackage(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = _travelPackageService.GetDetailsForTravelPackage(id);
            if (product != null)
            {
                _travelPackageService.DeleteTravelPackage(id);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
