using FitnessCenter.Data;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessCenter.Web.Controllers
{
    public class ReservationsController : Controller
    {

        private readonly DatabaseContext _databaseContext;
        public ReservationsController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;   
        }
        [HttpGet]
        public IActionResult Index()
        {
            var reservations = _databaseContext.Reservations.Select(r => new Reservation
            {
                DateTimeFrom = r.DateTimeFrom,
                DateTimeTo = r.DateTimeTo,
                UserId = r.UserId,
                FitnessRoomId = r.FitnessRoomId,
                CoachId = r.CoachId,
                Confirmed = r.Confirmed
            }).ToList();

            return View(new ReservationsCreateViewModel { Reservations = reservations });
        }
        [HttpGet]
        public IActionResult Add(int userId)
        {
            var viewModel = new ReservationsCreateViewModel
            {
                FitnessRooms = _databaseContext.FitnessRooms.Select(fr => new SelectListItem
                {
                    Text = fr.Name,
                    Value = fr.Id.ToString()
                }).ToList(),
                Coaches = _databaseContext.Users.Where(r=> r.Role == Role.Coach).Select(u => new SelectListItem
                {
                    Text = u.FirstName + " " + u.LastName,
                    Value = u.Id.ToString()
                }).ToList(),
                DateTimeFrom = DateTime.Now,
                DateTimeTo = DateTime.Now,
            };
            
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Add(ReservationsCreateViewModel viewModel)
        {
            var reservation = new Reservation
            {
                DateTimeFrom = viewModel.DateTimeFrom,
                DateTimeTo = viewModel.DateTimeTo,
                FitnessRoomId = viewModel.FitnessRoomId,
                Confirmed = false,
                UserId = viewModel.UserId,
                CoachId = viewModel.CoachId,
            };
            
            _databaseContext.Reservations.Add(reservation);
            _databaseContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
