using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using PeopleManager.Dto.Filters;
using PeopleManager.Dto.Organization;
using PeopleManager.Sdk;
using Vives.Services.Model;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class OrganizationController(OrganizationSdk organizationService) : Controller
    {
        private readonly OrganizationSdk _organizationService = organizationService;
        public async Task<IActionResult> Index([FromQuery]Paging paging, [FromQuery]OrganizationFilter? filter)
        {
            var organization = await _organizationService.Find(paging, filter);
            return View(organization.ToList());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrganizationRequests organization)
        {
            if (!ModelState.IsValid)
            {
                return View(organization);
            }
            var result = await _organizationService.Create(organization);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var organization = await _organizationService.Get(id);
            if (!organization.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(organization.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OrganizationResult organ)
        {
            if (!ModelState.IsValid)
            {
                return View(organ);
            }
            var result = await _organizationService.Update(organ.Id, new OrganizationRequests
            {
                Name = organ.Name,
                Description = organ.Description
            });
            if (!result.IsSuccess)
            {
                return View(organ);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var organization = await _organizationService.Get(id);
            if (organization == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(organization.Data);
        }

        [HttpPost("/{Controller}/Delete/{id:int}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromRoute] int id)
        {
            var org = await _organizationService.Get(id);
            if (org.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            await _organizationService.Delete(org.Data.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
