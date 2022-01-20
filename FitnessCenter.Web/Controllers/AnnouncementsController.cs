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
    public class AnnouncementsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFlashMessage _flashMessage;
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager _userManager;
        public AnnouncementsController(IMapper mapper, DatabaseContext databaseContext, UserManager userManager, IFlashMessage flashMessage)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _flashMessage = flashMessage;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Manage(int id)
        {

            AnnouncementsManageViewModel viewModel;

            if (id == 0)
            {
                viewModel = new AnnouncementsManageViewModel
                {
                    AuthorId = 1,
                    UserId = _userManager.Get().Id
                };
            }
            else
            {
                viewModel = _databaseContext.Announcements
                    .Where(a => a.Id == id)
                    .Select(a => _mapper.Map<AnnouncementsManageViewModel>(a)).Single();
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(AnnouncementsManageViewModel viewModel)
        {
            try
            {
                Announcement announcement;

                if (viewModel.Id == 0)
                {
                    announcement = new Announcement();
                    _databaseContext.Add(announcement);
                }
                else
                {
                    announcement = _databaseContext.Announcements.Find(viewModel.Id);
                }
                _mapper.Map(viewModel, announcement);
                _databaseContext.SaveChanges();

                if (viewModel.Id == 0)
                    _flashMessage.Confirmation(Translations.AnnouncementAddSuccess);
                else
                    _flashMessage.Confirmation(Translations.AnnouncementEditSuccess);
            }
            catch
            {
                if (viewModel.Id == 0)
                    _flashMessage.Danger(Translations.AnnouncementAddFailure);
                else
                    _flashMessage.Danger(Translations.AnnouncementEditFailure);
            }


            return Redirect("/Home/Index");
        }
    }
}
