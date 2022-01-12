using AutoMapper;
using FitnessCenter.Data;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.Resources;
using FitnessCenter.Web.Utilities.Constants;
using FitnessCenter.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Vereyon.Web;

namespace FitnessCenter.Web.Controllers
{
    public class GoalTypesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFlashMessage _flashMessage;
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager _userManager;
        public GoalTypesController(IMapper mapper, DatabaseContext databaseContext, UserManager userManager, IFlashMessage flashMessage)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _flashMessage = flashMessage;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var goalTypes = _databaseContext.GoalTypes.ToList();
            return View(new GoalTypesIndexViewModel
            {
                goalTypes = goalTypes
            });
        }

        [HttpGet]
        public IActionResult Manage(int id)
        {

            GoalTypesManageViewModel viewModel;

            if (id == 0)
            {
                viewModel = new GoalTypesManageViewModel
                {
                    UserId = _userManager.Get().Id
                };
            }
            else
            {
                viewModel = _databaseContext.GoalTypes
                    .Where(gt => gt.Id == id)
                    .Select(gt => _mapper.Map<GoalTypesManageViewModel>(gt)).Single();
            }
            return View(viewModel);
        }


        [HttpPost]

        public IActionResult Manage(GoalTypesManageViewModel viewModel)
        {
            try
            {
                GoalType gType;

                if (viewModel.Id == 0)
                {
                    gType = new GoalType();
                    _databaseContext.Add(gType);
                }
                else
                {
                    gType = _databaseContext.GoalTypes.Find(viewModel.Id);
                }
                _mapper.Map(viewModel, gType);
                _databaseContext.SaveChanges();

                if (viewModel.Id == 0)
                    _flashMessage.Confirmation(Translations.GoalTypeAddSuccess);
                else
                    _flashMessage.Confirmation(Translations.GoalTypeEditSuccess);
            }
            catch
            {
                if (viewModel.Id == 0)
                    _flashMessage.Danger(Translations.GoalTypeAddFailure);
                else
                    _flashMessage.Danger(Translations.GoalTypeEditFailure);
            }


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var gTypes = _databaseContext.GoalTypes.Find(id);
                _databaseContext.Remove(gTypes);
                _databaseContext.SaveChanges();

                _flashMessage.Confirmation(Translations.DeleteSuccess);
            }
            catch
            {
                _flashMessage.Confirmation(Translations.DeleteFail);
            }

            return RedirectToAction("Index");
        }
    }
}

