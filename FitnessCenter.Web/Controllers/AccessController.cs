using FitnessCenter.Data;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.Utilities;
using FitnessCenter.Web.Utilities.Constants;
using FitnessCenter.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.Web.Controllers
{
    public class AccessController : Controller
    {
        private readonly UserManager _userManager;
        private DatabaseContext _databaseContext;
        public AccessController(UserManager userManager,DatabaseContext databaseContext)
        {
            _userManager = userManager;
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (_userManager.IsSignedIn())
                return RedirectToAction("Index", "Home");

            return View("SignIn");
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View("SignIn");
        }

        [HttpPost]
        public IActionResult SignIn(AccessSignInViewModel viewModel)
        {
            var users = _databaseContext.Users.ToList();
            foreach (var  user in users)
            {
                if(user.Username == viewModel.Username && Cryptography.Hash.Validate(viewModel.Password, user.PasswordSalt, user.PasswordHash))
                {
                    _userManager.SignIn(user);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("SignIn");
        }

        [HttpGet]
        public new IActionResult SignOut()
        {
            _userManager.SignOut();
            return RedirectToAction("SignIn");
        }
    }
}
