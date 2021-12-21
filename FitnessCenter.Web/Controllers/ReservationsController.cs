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

        public IActionResult Create(int UserId)
        {
            var reservation = new ReservationsCreateViewModel
            {
                FitnessRooms = _databaseContext.FitnessRooms.Select(selector => new SelectListItem
                {
                    Text = selector.Name + " - " + selector.Price,
                    Value = selector.Id.ToString()
                }).ToList(),

                DateTimeFrom = DateTime.Now,
                DateTimeTo = DateTime.Now,
                UserId = UserId
                
        };
           
            return View(reservation);
        }

        public string Submit(ReservationsCreateViewModel reservation)
        {
            Reservation _reservation = new Reservation
            {
                DateTimeFrom = reservation.DateTimeFrom,
                DateTimeTo = reservation.DateTimeTo,
                FitnessRoomId = reservation.FitnessRoomId,
                Confirmed = false,
                UserId = reservation.UserId
            };

            _databaseContext.Reservations.Add(_reservation);
            _databaseContext.SaveChanges();

            return "OK";
        }


        //public double DateDiff(DateTime d1, DateTime d2)
        //{
        //    TimeSpan ts = d2 - d1;

        //    return ts.TotalHours;
        //}
    }
}
