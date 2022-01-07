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
    public class EventsController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        private readonly UserManager _userManager;
        private readonly IFlashMessage _flashMessage;
        public EventsController(DatabaseContext databaseContext, IMapper mapper, UserManager userManager, IFlashMessage flashMessage)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _flashMessage = flashMessage;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var events = _databaseContext.Events.ToList();

            return View(new EventsIndexViewModel
            {
                Events = events
            });
        }
        [HttpGet]
        public IActionResult View(int id)
        {
            var _event = _databaseContext.Events.Where(e => e.Id == id).Single();
           
            return View(new EventsIndexViewModel
            {
                Event = _event
            });
        }

        [HttpGet]
        public IActionResult Manage(int id)
        {
            EventsManageViewModel viewModel;

            if(id == 0)
            {
                viewModel = new EventsManageViewModel
                {
                    UserId = _userManager.Get().Id,
                    Rate = 0
                };
            }
            else
            {
                viewModel = _databaseContext.Events
                    .Where(e => e.Id == id)
                    .Select(e => _mapper.Map<EventsManageViewModel>(e)).Single();
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(EventsManageViewModel viewModel)
        {
            try
            {
                Event _event;

                if (viewModel.Id == 0)
                {
                    _event = new Event();
                    _databaseContext.Add(_event);
                }
                else
                {
                    _event = _databaseContext.Events.Find(viewModel.Id);
                }

                _event.Photo = new Photo
                {
                    Data = await viewModel.Photo.GetBytes()
                };

                _mapper.Map(viewModel, _event);
                _databaseContext.SaveChanges();

                if (viewModel.Id == 0)
                    _flashMessage.Confirmation(Translations.EventAddSuccess);
                else
                    _flashMessage.Confirmation(Translations.EventEditSuccess);
            }
            catch
            {
                if (viewModel.Id == 0)
                    _flashMessage.Danger(Translations.EventAddFailure);
                else
                    _flashMessage.Danger(Translations.EventEditFailure);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var _event = _databaseContext.Events.Find(id);
                _databaseContext.Remove(_event);


                _databaseContext.SaveChanges();
                _flashMessage.Confirmation(Translations.DeleteSuccess);
            }
            catch
            {
                _flashMessage.Danger(Translations.DeleteFail);
            }
            return RedirectToAction("Index");
        }
    }
}
