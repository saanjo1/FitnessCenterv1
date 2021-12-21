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

      


        public IActionResult Create()
        {
            var reservation = new ReservationsCreateViewModel
            {
                FitnessRooms = _databaseContext.FitnessRooms.Select(selector => new SelectListItem
                {
                    Text = selector.Name,
                    Value = selector.Id.ToString()
                }).ToList(),
                DateTimeFrom = DateTime.Now,
                DateTimeTo = DateTime.Now,
                TotalPrice = 0
        };
           
            return View(reservation);
        }
    }
}
