using Microsoft.AspNetCore.Mvc;
using PeopleManager.Core;
using PeopleManager.Model;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly PeopleManagerDbContext _DbContext;
        public OrganizationController(PeopleManagerDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var organization = _DbContext.Organizations;
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
            _DbContext.Organizations.Add(organization);
            _DbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var organization = _DbContext.Organizations.FirstOrDefault(p => p.Id == id);
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
            /*var dborganizaton = _DbContext.Organizations.FirstOrDefault(p => p.Id == organ.Id);
            if (dborganizaton == null)
            {
                return RedirectToAction(nameof(Index));
            }*/
            if (!ModelState.IsValid)
            {
                return View(organ);
            }
            _DbContext.Organizations.Update(organ);
            _DbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var organization = _DbContext.Organizations.FirstOrDefault(p => p.Id == id);
            if (organization == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(organization);
        }

        [HttpPost("/{Controller}/Delete/{id:int}"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed([FromRoute] int id)
        {
            var org = _DbContext.Organizations.FirstOrDefault(o => o.Id == id);
            if (org == null)
            {
                return RedirectToAction(nameof(Index));
            }
            _DbContext.Organizations.Remove(org);
            _DbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
