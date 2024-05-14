using ASP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleManager.Core;
using PeopleManager.Model;
using PeopleManager.Services;


namespace PeopleManager.Ui.Mvc.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PersonService _personService;
        private readonly OrganizationService _organizationService;
        public PeopleController(PersonService personService, OrganizationService organizationService)
        {
            _personService = personService;
            _organizationService = organizationService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var people = _personService.Find();
            return View(people.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return createActionView();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (!ModelState.IsValid)
            {
                return createActionView(person);
            }

            _personService.Create(person);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Organizations = _organizationService.Find();
            var person = _personService.Get(id);
            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (!ModelState.IsValid)
            {
                return createActionView(person);
            }

            _personService.Update(person.Id, person);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var person = _personService.Get(id);
            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed([FromForm] int id)
        {
            var person = _personService.Get(id);
            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }
            _personService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private ViewResult createActionView(Person? person = null)
        {
            ViewBag.Organizations = _DbContext.Organizations.ToList();
            return View(person);
        }
    }
}
