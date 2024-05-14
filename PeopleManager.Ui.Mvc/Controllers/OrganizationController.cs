using Microsoft.AspNetCore.Mvc;
using PeopleManager.Core;
using PeopleManager.Model;
using PeopleManager.Services;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly OrganizationService _organizationService;
        public OrganizationController(OrganizationService organizationService)
        {
            _organizationService = organizationService;
        }
        public IActionResult Index()
        {
            var organization = _organizationService.Find();
            return View(organization.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return View(organization);
            }
            _organizationService.Create(organization);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var organization = _organizationService.Get(id);
            if (organization == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(organization);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Organization organ)
        {
            if (!ModelState.IsValid)
            {
                return View(organ);
            }
            _organizationService.Update(organ.Id, organ);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var organization = _organizationService.Get(id);
            if (organization == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(organization);
        }

        [HttpPost("/{Controller}/Delete/{id:int}"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed([FromRoute] int id)
        {
            var org = _organizationService.Get(id);
            if (org == null)
            {
                return RedirectToAction(nameof(Index));
            }
            _organizationService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
