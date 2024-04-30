using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleManager.Core;
using PeopleManager.Model;


namespace PeopleManager.Ui.Mvc.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PeopleManagerDbContext _DbContext;
        public PeopleController(PeopleManagerDbContext peopleManagerDbContext)
        {
            _DbContext = peopleManagerDbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var people = _DbContext.People
                .Include(p => p.Organization);
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
            _DbContext.People.Add(person);
            _DbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Organizations = _DbContext.Organizations.ToList();
            var person = _DbContext.People.FirstOrDefault(p => p.Id == id);
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
            _DbContext.People.Update(person);
            _DbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var person = _DbContext.People.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        [HttpPost("/{Controller}/Delete/{routeid:int?}"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed([FromForm] int formid, [FromRoute] int routeid)
        {
            int id = formid == 0 ? routeid : formid;
            var p = _DbContext.People.FirstOrDefault(p => p.Id == id);
            if (p == null)
            {
                return RedirectToAction(nameof(Index));
            }
            _DbContext.People.Remove(p);
            _DbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private ViewResult createActionView(Person? person = null)
        {
            ViewBag.Organizations = _DbContext.Organizations.ToList();
            return View(person);
        }
    }
}
