using FitnessCenter.Data;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
                Id = r.Id,
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
                Coaches = _databaseContext.Users.Where(r => r.Role == Role.Coach).Select(u => new SelectListItem
                {
                    Text = u.FirstName + " " + u.LastName,
                    Value = u.Id.ToString()
                }).ToList(),
                DateTimeFrom = DateTime.Now,
                DateTimeTo = DateTime.Now,
                UserId = userId
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
            if(reservation.UserId != 1)
            {
                _databaseContext.Reservations.Add(reservation);
            }
            else
            {
                _databaseContext.Entry(reservation).State = EntityState.Modified;
            }
            
            _databaseContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int reservationId, int coachId, int userId)
        {
            var FitnessRoomsList = _databaseContext.FitnessRooms.OrderBy(fr => fr.Name)
                .Select(fr => new SelectListItem
                {
                    Text = fr.Name,
                    Value = fr.Id.ToString()
                }).ToList();

            var coachesList = _databaseContext.Users.OrderBy(fr => fr.Id)
               .Select(fr => new SelectListItem
               {
                   Text = fr.FirstName,
                   Value = fr.Id.ToString()
               }).ToList();

            var reservations = _databaseContext.Reservations
                .Where(r => r.Id == reservationId)
                .Select(rc => new ReservationsCreateViewModel
                {
                    UserId = userId,
                    CoachId= rc.Id,
                    ReservationId = rc.Id,
                    DateTimeFrom = rc.DateTimeFrom,
                    DateTimeTo = rc.DateTimeTo,
                    FitnessRoomId = rc.FitnessRoomId
                }).Single();

            reservations.FitnessRooms = FitnessRoomsList;
            reservations.Coaches = coachesList;

            return View("Edit", reservations);
        }
    }
}
