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
    public class SponsorsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFlashMessage _flashMessage;
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager _userManager;

        public SponsorsController(IMapper mapper, IFlashMessage flashMessage, DatabaseContext databaseContext, UserManager userManager)
        {
            _mapper = mapper;
            _flashMessage = flashMessage;
            _databaseContext = databaseContext;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var _sponsors = _databaseContext.Sponsors
                .Include(s=>s.User)
                .ToList();

            return View(new SponsorsIndexViewModel
            {
                Sponsors = _sponsors
            });
        }

        [HttpGet]
        public IActionResult Manage(int id)
        {
            SponsorsManageViewModel viewModel;

            if (id == 0)
            {
                viewModel = new SponsorsManageViewModel()
                {
                    UserId = _userManager.Get().Id
                };
            }
            else
            {
                viewModel = _databaseContext.Sponsors
                    .Where(s => s.Id == id)
                    .Select(s => _mapper.Map<SponsorsManageViewModel>(s)).Single();
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var sponsor = _databaseContext.Sponsors.Find(id);
                _databaseContext.Remove(sponsor);

                var supplements = _databaseContext.Supplements.Where(s => s.SponsorId == s.Id).ToList();
                supplements.ForEach(s => { s.SponsorId = null; });


                _databaseContext.SaveChanges();
                _flashMessage.Confirmation(Translations.DeleteSuccess);
            }
            catch
            {
                _flashMessage.Danger(Translations.DeleteFail);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Manage(SponsorsManageViewModel viewModel)
        {
            try
            {
                Sponsor sponsor;

                if (viewModel.Id == 0)
                {
                    sponsor = new Sponsor();
                    _databaseContext.Add(sponsor);
                }
                else
                {
                    sponsor = _databaseContext.Sponsors.Find(viewModel.Id);
                }
                sponsor.Photo = new Photo
                {
                    Data = await viewModel.Photo.GetBytes()
                };

                _mapper.Map(viewModel, sponsor);
                _databaseContext.SaveChanges();

                if (viewModel.Id == 0)
                    _flashMessage.Confirmation(Translations.SponsorAddSuccess);
                else
                    _flashMessage.Confirmation(Translations.SponsorEditSuccess);
            }
            catch
            {
                if (viewModel.Id == 0)
                    _flashMessage.Danger(Translations.SponsorAddFailure);
                else
                    _flashMessage.Danger(Translations.SponsorEditFailure);
            }

            return RedirectToAction("Index");
        }

      
    }
}
