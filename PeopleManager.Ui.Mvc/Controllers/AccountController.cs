using Microsoft.AspNetCore.Mvc;
using PeopleManager.Model;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            return LocalRedirect($"Home/Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            return View(model);
        }
    }
}
