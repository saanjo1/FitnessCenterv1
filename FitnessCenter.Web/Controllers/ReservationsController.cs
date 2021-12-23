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
        public IActionResult Add(int userId, int reservationId, int coachId)
        {
            var FitnessRoomsList = _databaseContext.FitnessRooms
                .Select(fr => new SelectListItem
                {
                    Text = fr.Name,
                    Value = fr.Id.ToString()
                }).ToList();

            var coachesList = _databaseContext.Users.Where(r => r.Role == Role.Coach)
               .Select(fr => new SelectListItem
               {
                   Text = fr.FirstName + " " + fr.LastName,
                   Value = fr.Id.ToString()
               }).ToList();


            ReservationsCreateViewModel viewModel;
            if(reservationId == 0)
            {
                viewModel = new ReservationsCreateViewModel();
            }
            else
            {
                viewModel = _databaseContext.Reservations.Where(r => r.Id == reservationId)
                            .Select(s => new ReservationsCreateViewModel
                            {
                                UserId = userId,
                                DateTimeFrom = s.DateTimeFrom,
                                DateTimeTo = s.DateTimeTo,
                                CoachId = coachId,
                                FitnessRoomId = s.FitnessRoomId,
                                ReservationId = 5
                            }).Single();
            }

            viewModel.FitnessRooms = FitnessRoomsList;
            viewModel.Coaches = coachesList;


                //FitnessRooms = _databaseContext.FitnessRooms.Select(fr => new SelectListItem
                //{
                //    Text = fr.Name,
                //    Value = fr.Id.ToString()
                //}).ToList(),
                //Coaches = _databaseContext.Users.Where(r => r.Role == Role.Coach).Select(u => new SelectListItem
                //{
                //    Text = u.FirstName + " " + u.LastName,
                //    Value = u.Id.ToString()
                //}).ToList(),
                //DateTimeFrom = DateTime.Now,
                //DateTimeTo = DateTime.Now,
                //UserId = userId
            

            return View("Add", viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ReservationsCreateViewModel viewModel)
        {

            Reservation _reservation;

            if (viewModel.ReservationId == 0)
            {
                _reservation = new Reservation();
                _databaseContext.Add(_reservation);
            }
            else
            {
                _reservation = _databaseContext.Reservations.Find(viewModel.ReservationId);
            }

            _reservation.DateTimeTo = viewModel.DateTimeTo;
            _reservation.DateTimeFrom = viewModel.DateTimeFrom;
            _reservation.CoachId = viewModel.CoachId;
            _reservation.UserId = viewModel.UserId;
            _reservation.FitnessRoomId = viewModel.FitnessRoomId;

            _databaseContext.SaveChanges();



            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public IActionResult Edit(int reservationId, int coachId, int userId)
        //{
        //    var FitnessRoomsList = _databaseContext.FitnessRooms.OrderBy(fr => fr.Name)
        //        .Select(fr => new SelectListItem
        //        {
        //            Text = fr.Name,
        //            Value = fr.Id.ToString()
        //        }).ToList();

        //    var coachesList = _databaseContext.Users.OrderBy(fr => fr.Id)
        //       .Select(fr => new SelectListItem
        //       {
        //           Text = fr.FirstName,
        //           Value = fr.Id.ToString()
        //       }).ToList();

        //    var reservations = _databaseContext.Reservations
        //        .Where(r => r.Id == reservationId)
        //        .Select(rc => new ReservationsCreateViewModel
        //        {
        //            UserId = userId,
        //            CoachId= rc.Id,
        //            ReservationId = rc.Id,
        //            DateTimeFrom = rc.DateTimeFrom,
        //            DateTimeTo = rc.DateTimeTo,
        //            FitnessRoomId = rc.FitnessRoomId
        //        }).Single();

        //    reservations.FitnessRooms = FitnessRoomsList;
        //    reservations.Coaches = coachesList;

        //    return View("Edit", reservations);
        //}
    }
}
