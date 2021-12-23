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
            var _reservations = _databaseContext.Reservations.Select(r => new Reservation
            {
                DateTimeFrom = r.DateTimeFrom,
                DateTimeTo = r.DateTimeTo,
                UserId = r.UserId,
                FitnessRoomId = r.FitnessRoomId,
                CoachId = r.CoachId,
                Id = r.Id,
                Confirmed = r.Confirmed,
            }).ToList();

            var reservationIndex = new ReservationsCreateViewModel();
            reservationIndex.reservations = _reservations;

            return View(reservationIndex);
        }

        [HttpGet]
        public IActionResult Add(int reservationId, int userId, int coachId)
        {
            var fitnessRooms = _databaseContext.FitnessRooms
                .Select(fr => new SelectListItem
                {
                    Text = fr.Name,
                    Value = fr.Id.ToString()
                }).ToList();

            var coaches = _databaseContext.Users
                .Where(r => r.Role == Data.Entities.Role.Coach)
                .Select(s => new SelectListItem
                {
                    Text = s.FirstName + " " + s.LastName,
                    Value = s.Id.ToString(),
                }).ToList();

            var users = _databaseContext.Users    
                .Select(s => new SelectListItem
                {
                    Text = s.FirstName + " " + s.LastName,
                    Value = s.Id.ToString(),
                }).ToList();

            ReservationsCreateViewModel _reservationsCreateViewModel;
            if(reservationId == 0)
            {
                _reservationsCreateViewModel = new ReservationsCreateViewModel();
            }
            else
            {
                _reservationsCreateViewModel = _databaseContext.Reservations
                    .Where(r => r.Id == reservationId)
                    .Select(s => new ReservationsCreateViewModel
                    {
                        DateTimeFrom = DateTime.Now,
                        DateTimeTo = DateTime.Now,
                        CoachId = s.CoachId,
                        UserId = s.UserId,
                        FitnessRoomId = s.FitnessRoomId,
                        Confirmed = s.Confirmed,
                        Id = s.Id
                    }).Single();
            }
            _reservationsCreateViewModel.FitnessRooms = fitnessRooms;
            _reservationsCreateViewModel.Coaches = coaches;
            _reservationsCreateViewModel.Users = users;

            return View("Add",_reservationsCreateViewModel);
        }
        [HttpPost]
        public IActionResult Add(ReservationsCreateViewModel _viewModel)
        {
            Reservation reservation;

            if(_viewModel.Id == 0)
            {
                reservation = new Reservation();
                _databaseContext.Add(reservation);
            }
            else
            {
                reservation = _databaseContext.Reservations.Find(_viewModel.Id);
            }
            reservation.DateTimeTo = _viewModel.DateTimeTo;
            reservation.DateTimeFrom = _viewModel.DateTimeFrom;
            reservation.CoachId = _viewModel.CoachId;
            reservation.UserId = _viewModel.UserId;
            reservation.FitnessRoomId = _viewModel.FitnessRoomId;
            reservation.Confirmed = _viewModel.Confirmed;

            return RedirectToAction("Index");
        }
    }
}
