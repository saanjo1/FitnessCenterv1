using AutoMapper;
using FitnessCenter.Data;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.Resources;
using FitnessCenter.Web.Utilities;
using FitnessCenter.Web.Utilities.Constants;
using FitnessCenter.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vereyon.Web;

namespace FitnessCenter.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFlashMessage _flashMessage;
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager _userManager;
        public UsersController(IMapper mapper, DatabaseContext databaseContext, UserManager userManager, IFlashMessage flashMessage)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _flashMessage = flashMessage;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            var users = _databaseContext.Users.Select(selector => new User
            {
                FirstName = selector.FirstName,
                LastName = selector.LastName,
                Email = selector.Email,
                Username = selector.Username,
                Role = selector.Role,
                NotificationNumber = selector.NotificationNumber,
                Id = selector.Id
            }).ToList();

            var userIndex = new UsersIndexViewModel();
            userIndex.Users = users;

            return View(userIndex);
        }

        [HttpGet]
        [ActionName("change_password")]
        public IActionResult ChangePassword(int Id)
        {
            UserChangePasswordVM viewModel = new UserChangePasswordVM
            {
                UserId = _databaseContext.Users.Where(x => x.Id == Id).Select(y => y.Id).FirstOrDefault()
            };
            return PartialView("ChangePassword", viewModel);

        }

        [HttpPost]
        [ActionName("change_password")]
        public IActionResult ChangePassword(UserChangePasswordVM viewModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            if (viewModel.ConfirmPassword != viewModel.NewPassword)
            {
                _flashMessage.Danger(Translations.PasswordsMatchFailure);
                return RedirectToAction("Index");
            }

            try
            {
                User user = _databaseContext.Users.Find(viewModel.UserId);
                var salt = Cryptography.Salt.Create();
                user.PasswordSalt = salt;
                user.PasswordHash = Cryptography.Hash.Create(viewModel.NewPassword, salt);

                _databaseContext.Users.Update(user);
                _databaseContext.SaveChanges();


                _flashMessage.Confirmation(Translations.ConfirmPasswordSuccess);
            }
            catch
            {
                _flashMessage.Danger(Translations.ConfirmPasswordFailure);
            }

            return Redirect("/users/index");

        }


        [HttpGet]
        public IActionResult Manage(int id)
        {
            UserManageViewModel viewModel;
            if (id == 0)
            {
                viewModel = new UserManageViewModel();
            }
            else
            {
                viewModel = _databaseContext.Users.Where(x => x.Id == id).Select(x => _mapper.Map<UserManageViewModel>(x)).Single();
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(UserManageViewModel viewModel)
        {
            try
            {
                User user;
                if (viewModel.Id == 0)
                {
                    user = new User();
                    _databaseContext.Add(user);
                }
                else
                {
                    user = _databaseContext.Users.Find(viewModel.Id);
                }
                _mapper.Map(viewModel, user);
                _databaseContext.SaveChanges();

                if (viewModel.Id == 0)
                    _flashMessage.Confirmation(Translations.UserAddSuccess);
                else
                    _flashMessage.Confirmation(Translations.UserEditSuccess);
            }
            catch
            {
                if (viewModel.Id == 0)
                    _flashMessage.Danger(Translations.UserAddFailure);
                else
                    _flashMessage.Danger(Translations.UserEditFailure);
            }
            return Redirect("/Users/Index");


        }

    }
}

