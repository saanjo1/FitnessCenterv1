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
            List<ReservationIndexViewModel.Row> reservations =
                _databaseContext.Reservations.Select(r => new ReservationIndexViewModel.Row
                {
                    ReservationId = r.Id,
                    DateTimeFrom = r.DateTimeFrom,
                    DateTimeTo = r.DateTimeTo,
                    Coach = r.Coach.FirstName + " " + r.Coach.LastName,
                    User = r.User.FirstName + " " + r.User.LastName,
                    FitnessRoom = r.FitnessRoom.Name

                }).ToList();

            ReservationIndexViewModel ReservationModel = new()
            {
                Rows = reservations
            };

            return View(ReservationModel);

        }

        public IActionResult Create(int reservationId)
        {
            List<SelectListItem> fitnessRooms = _databaseContext.FitnessRooms
                .Select(fr => new SelectListItem
                {
                    Text = fr.Name,
                    Value = fr.Id.ToString()
                }).ToList();

            List<SelectListItem> coaches = _databaseContext.Users
                .Where(r => r.Role == Data.Entities.Role.Coach)
                .Select(s => new SelectListItem
                {
                    Text = s.FirstName + " " + s.LastName,
                    Value = s.Id.ToString(),
                }).ToList();

            List<SelectListItem> users = _databaseContext.Users    
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
                        DateTimeFrom = s.DateTimeFrom,
                        DateTimeTo = s.DateTimeTo,
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

            return View(_reservationsCreateViewModel);
        }

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

            return Redirect("/Reservations");
        }


    }
}
