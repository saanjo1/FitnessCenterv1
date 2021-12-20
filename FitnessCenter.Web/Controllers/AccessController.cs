using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.Web.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Index()
        {
            // TODO: Check if user is already signed in. If yes then redirect to home page, if not then show sign in form.

            return View();
        }
       
        public IActionResult SignIn()
        {
            return View("SignOut");
        }

        public new IActionResult SignOut()
        {
            // TODO: Remove user from session

            return View("SignIn");
        }
    }
}
