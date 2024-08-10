using Eshop.DomainEntities;
using Eshop.DomainEntities.Domain;
using Eshop.Service.Implementation;
using Eshop.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EshopWebApplication1.Controllers
{
    public class AgenciesController : Controller
    {
        private readonly IAgencyService _agencyService;

        public AgenciesController(IAgencyService agencyService)
        {
            _agencyService = agencyService;
        }

        // GET: Agencies
        public IActionResult Index()
        {
            return View(_agencyService.GetAllAgencies());
        }

        // GET: Agencies/Details/Id
        public IActionResult Details(Guid? id)
        {
            var agency = _agencyService.GetDetailsForAgency(id);
            return View(agency);
        }

        // GET: Agencies/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Agency agency)
        {
            _agencyService.CreateNewAgency(agency);

            return RedirectToAction(nameof(Index));
        }

        // GET: Agencies/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var agency = _agencyService.GetDetailsForAgency(id);
            if (agency == null)
            {
                return NotFound();
            }
            return View(agency);
        }

        // POST: Agencies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Email,Phone,Address")] Agency agency)
        {
            if (id != agency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _agencyService.UpdateExistingAgency(agency);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(agency);
        }

        // GET: Agencies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agency = _agencyService.GetDetailsForAgency(id);
            if (agency == null)
            {
                return NotFound();
            }

            return View(agency);
        }

        // POST: Agencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var agency = _agencyService.GetDetailsForAgency(id);
            if (agency != null)
            {
                _agencyService.DeleteAgency(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
