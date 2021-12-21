using FitnessCenter.Data;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.Web.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public ReservationsController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;   
        }
        public IActionResult Create()
        {
            var ReservationModel = new ReservationsCreateViewModel()
            {
                Reservation = new Reservation(),
            };
            return View();
        }
    }
}
