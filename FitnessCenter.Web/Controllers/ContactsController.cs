using FitnessCenter.Data;
using FitnessCenter.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.Web.Controllers
{
    public class ContactsController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public ContactsController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IActionResult Index()
        {
            var contacts = _databaseContext.Contacts.ToList();
            return View(new ContactsIndexViewModel
            {
                Contacts = contacts
            });
        }
    }
}
