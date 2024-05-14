using Microsoft.AspNetCore.Mvc;
using PeopleManager.Dto.Filters;
using PeopleManager.Dto.Person;
using PeopleManager.Sdk;
using Vives.Services.Model;


namespace PeopleManager.Ui.Mvc.Controllers
{
    public class PeopleController(PeopleSdk peopleService, OrganizationSdk organizationService) : Controller
    {
        private readonly PeopleSdk _peopleService = peopleService;
        private readonly OrganizationSdk _organizationService = organizationService;

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]Paging paging, [FromQuery]PersonFilter? filter, [FromQuery]Sorting? sorting)
        {
            var people = await _peopleService.Find(paging, filter, sorting);
            return View(people.ToList());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return await createActionView(new PersonRequests{FirstName = "",LastName = ""});
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonRequests person)
        {
            if (!ModelState.IsValid)
            {
                return await createActionView(person);
            }

            var result = _peopleService.Create(person).Result;

            if (!result.IsSuccess)
            {
                return await createActionView(person);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var organizationresult = await _organizationService.Find(new Paging {Limit = 1000});
            ViewBag.Organizations = organizationresult;
            var person = await _peopleService.Get(id);
            if (!person.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(person.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PersonResults person)
        {
            if (!ModelState.IsValid)
            {
                return await createActionView(person);
            }

            var result = _peopleService.Update(person.Id, new PersonRequests
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                OrganizationId = person.OrganizationId
            });

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _peopleService.Get(id);
            if (!person.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(person.Data);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromForm] int id)
        {
            var person = await _peopleService.Get(id);
            if (!person.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            var result = await _peopleService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<ViewResult> createActionView<T>(T? person)
        {
            ViewBag.Organizations = await _organizationService.Find(new Paging {Limit = 1000});
            return View(person);
        }
    }
}
