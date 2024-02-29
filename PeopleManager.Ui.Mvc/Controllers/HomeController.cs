using Microsoft.AspNetCore.Mvc;
using PeopleManager.Ui.Mvc.Models;
using System.Diagnostics;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            PeopleController persons = new PeopleController();
            var people = persons.GetPeople();
            return View(people);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
