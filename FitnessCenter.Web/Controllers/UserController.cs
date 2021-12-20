using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserPreview()
        {
            return View();
        }
    }
}
