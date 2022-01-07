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
    public class ContactsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFlashMessage _flashMessage;
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager _userManager;
        public ContactsController(IMapper mapper, DatabaseContext databaseContext, UserManager userManager, IFlashMessage flashMessage)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _flashMessage= flashMessage;
            _userManager= userManager;  
        }
        public IActionResult Index()
        {
            var contacts = _databaseContext.Contacts.ToList();
            return View(new ContactsIndexViewModel
            {
                Contacts = contacts
            });
        }

        [HttpGet]
        public IActionResult Manage(int id)
        {

            ContactsManageViewModel viewModel;

            if(id == 0)
            {
                viewModel = new ContactsManageViewModel
                {
                    UserId = _userManager.Get().Id
                };
            }
            else
            {
                viewModel = _databaseContext.Contacts
                    .Where(c => c.Id == id)
                    .Select(c => _mapper.Map<ContactsManageViewModel>(c)).Single();
            }
            return View(viewModel);
        }


        [HttpPost]

        public async Task<IActionResult> Manage(ContactsManageViewModel viewModel)
        {
            try
            {
                Contact contact;

                if (viewModel.Id == 0)
                {
                    contact = new Contact();
                    _databaseContext.Add(contact);
                }
                else
                {
                    contact = _databaseContext.Contacts.Find(viewModel.Id);
                }

                contact.Photo = new Photo
                {
                    Data = await viewModel.Photo.GetBytes()
                };

                _mapper.Map(viewModel, contact);
                _databaseContext.SaveChanges();

                if (viewModel.Id == 0)
                    _flashMessage.Confirmation(Translations.ContactAddSuccess);
                else
                    _flashMessage.Confirmation(Translations.ContactEditSuccess);
            }
            catch
            {
                if (viewModel.Id == 0)
                    _flashMessage.Danger(Translations.ContactAddFailure);
                else
                    _flashMessage.Danger(Translations.ContactEditFailure);
            }


            return RedirectToAction("Index");
        }
}
    }

