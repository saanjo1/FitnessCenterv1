using AutoMapper;
using FitnessCenter.Data;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.Resources;
using FitnessCenter.Web.Utilities.Constants;
using FitnessCenter.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vereyon.Web;

namespace FitnessCenter.Web.Controllers
{
    public class SupplementsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFlashMessage _flashMessage;
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager _userManager;

        public SupplementsController(IMapper mapper, IFlashMessage flashMessage, DatabaseContext databaseContext, UserManager userManager)
        {
            _mapper = mapper;
            _flashMessage = flashMessage;
            _databaseContext = databaseContext;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var _supplements = _databaseContext.Supplements
                .Include(s => s.Sponsor)
                .ToList();

            return View(new SupplementsIndexViewModel
            {
                Supplements = _supplements
            });
        }

        [HttpGet]
        public IActionResult Manage(int id)
        {
            SupplementsManageViewModel viewModel;

            if (id == 0)
            {
                viewModel = new SupplementsManageViewModel()
                {

                };
            }
            else
            {
                viewModel = _databaseContext.Supplements
                    .Where(s => s.Id == id)
                    .Select(s => _mapper.Map<SupplementsManageViewModel>(s)).Single();
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(SupplementsManageViewModel viewModel)
        {

            try
            {
                Supplement supplement;

                if (viewModel.Id == 0)
                {
                    supplement = new Supplement();
                    _databaseContext.Add(supplement);
                }
                else
                {
                    supplement = _databaseContext.Supplements.Find(viewModel.Id);
                }

                if (viewModel.Photo != null)
                {
                    supplement.Photo = new Photo
                    {
                        Data = await viewModel.Photo.GetBytes()
                    };
                }
                _mapper.Map(viewModel, supplement);
                _databaseContext.SaveChanges();

                if (viewModel.Id == 0)
                    _flashMessage.Confirmation(Translations.SupplementAddSuccess);
                else
                    _flashMessage.Confirmation(Translations.SupplementEditSuccess);
            }
            catch
            {
                if (viewModel.Id == 0)
                    _flashMessage.Danger(Translations.SupplementAddFailure);
                else
                    _flashMessage.Danger(Translations.SupplementEditFailure);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var supplement = _databaseContext.Supplements.Find(id);
                _databaseContext.Remove(supplement);
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
