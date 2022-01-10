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
    public class EquipmentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFlashMessage _flashMessage;
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager _userManager;
        public EquipmentController(IMapper mapper, DatabaseContext databaseContext, UserManager userManager, IFlashMessage flashMessage)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _flashMessage = flashMessage;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var equipment = _databaseContext.Equipment.ToList();
            return View(new EquipmentIndexViewModel
            {
                equipment = equipment
            });
        }


        [HttpGet]
        public IActionResult Manage(int id)
        {

            EquipmentManageViewModel viewModel;

            if (id == 0)
            {
                viewModel = new EquipmentManageViewModel
                {
                    UserId = _userManager.Get().Id
                };
            }
            else
            {
                viewModel = _databaseContext.Equipment
                    .Where(e => e.Id == id)
                    .Select(e => _mapper.Map<EquipmentManageViewModel>(e)).Single();
            }
            return View(viewModel);
        }


        [HttpPost]

        public async Task<IActionResult> Manage(EquipmentManageViewModel viewModel)
        {
            try
            {
                Equipment equipment;

                if (viewModel.Id == 0)
                {
                    equipment = new Equipment();
                    _databaseContext.Add(equipment);
                }
                else
                {
                    equipment = _databaseContext.Equipment.Find(viewModel.Id);
                }

                if (viewModel.Photo != null)
                {
                    equipment.Photo = new Photo
                    {
                        Data = await viewModel.Photo.GetBytes()
                    };
                }
                _mapper.Map(viewModel, equipment);
                _databaseContext.SaveChanges();

                if (viewModel.Id == 0)
                    _flashMessage.Confirmation(Translations.EquipmentAddSuccess);
                else
                    _flashMessage.Confirmation(Translations.EquipmentEditSuccess);
            }
            catch
            {
                if (viewModel.Id == 0)
                    _flashMessage.Danger(Translations.EquipmentAddFailure);
                else
                    _flashMessage.Danger(Translations.EquipmentEditFailure);
            }


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var equipment = _databaseContext.Equipment.Find(id);
                _databaseContext.Remove(equipment);
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