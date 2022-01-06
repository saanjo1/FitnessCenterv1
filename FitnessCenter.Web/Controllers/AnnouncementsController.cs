using FitnessCenter.Data;
using FitnessCenter.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.Web.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public AnnouncementsController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IActionResult Index()
        {
            var announcements = _databaseContext.Announcements.ToList();
            return View(new AnnouncementsIndexViewModel
            {
                Announcements = announcements
            });
        }
    }
}
