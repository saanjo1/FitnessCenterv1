using FitnessCenter.Data;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.Resources;
using FitnessCenter.Web.Utilities;
using FitnessCenter.Web.Utilities.Constants;
using FitnessCenter.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Vereyon.Web;

namespace FitnessCenter.Web.Controllers
{
    public class AccessController : Controller
    {
        private readonly UserManager _userManager;
        private DatabaseContext _databaseContext;
        private readonly IFlashMessage _flashMessage;
        public AccessController(UserManager userManager, DatabaseContext databaseContext, IFlashMessage flashMessage)
        {
            _userManager = userManager;
            _databaseContext = databaseContext;
            _flashMessage = flashMessage;
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
            if (!ModelState.IsValid)
                return View(viewModel);


            var users = _databaseContext.Users.ToList();
            foreach (var user in users)
            {
                if (viewModel.Username == null)
                {
                    _flashMessage.Danger(Translations.InsertUsername);
                    return View("SignIn");
                }

                if (viewModel.Password == null)
                {
                    _flashMessage.Danger(Translations.InsertPassword);
                    return View("SignIn");
                }
                if (user.Username == viewModel.Username && Cryptography.Hash.Validate(viewModel.Password, user.PasswordSalt, user.PasswordHash))
                {
                    _userManager.SignIn(user);
                    return RedirectToAction("Index", "Home");
                }
            }
            _flashMessage.Danger(Translations.SignInFailed);
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
