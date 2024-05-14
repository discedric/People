using Microsoft.AspNetCore.Mvc;
using PeopleManager.Ui.Mvc.Models;
using System.Diagnostics;
using PeopleManager.Dto.Filters;
using PeopleManager.Dto.Identity;
using PeopleManager.Sdk;
using Vives.Services.Model;


namespace PeopleManager.Ui.Mvc.Controllers
{
    public class HomeController(PeopleSdk peopleService, IdentitySdk identitySdk) : Controller
    {
        private readonly PeopleSdk _peopleService = peopleService;
        private readonly IdentitySdk _identitySdk = identitySdk;
        public async Task<IActionResult> Index([FromQuery]Paging paging, [FromQuery]Sorting sorting)
        {
            identitySdk.Register(new RegisterRequest { Username = "Admin@admin.com", Password = "Cv07022004!" });
            var people = await _peopleService.Find(paging,null, sorting);
            return View(people.ToList());
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
