using AutoMapper;
using FitnessCenter.Data;
using FitnessCenter.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public EventsController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
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

        [HttpPost]
        public IActionResult Manage()
        {
            return View("Index");
        }
    }
}
