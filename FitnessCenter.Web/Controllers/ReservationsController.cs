using AutoMapper;
using CloudinaryDotNet.Actions;
using FitnessCenter.Data;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.Resources;
using FitnessCenter.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vereyon.Web;

namespace FitnessCenter.Web.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFlashMessage _flashMessage;
        private readonly DatabaseContext _databaseContext;

        public ReservationsController(IMapper mapper, IFlashMessage flashMessage, DatabaseContext databaseContext)
        {
            _mapper = mapper;
            _flashMessage = flashMessage;
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var reservations = _databaseContext.Reservations
                 .Include(r => r.FitnessRoom)
                 .Include(r=>r.User)
                 .Include(r=>r.Coach)
                 .ToList();

            return View(new ReservationsIndexViewModel
            {
                Reservations = reservations
            });
        }
        
        [HttpGet]
        public IActionResult Manage(int id)
        {
            ReservationsManageViewModel viewModel;
            
            if (id == 0)
            {
                viewModel = new ReservationsManageViewModel
                {
                    DateTimeFrom = DateTime.Now,
                    DateTimeTo = DateTime.Now
                };
            }
            else
            {
                viewModel = _databaseContext.Reservations
                    .Where(r => r.Id == id)
                    .Select(s => _mapper.Map<ReservationsManageViewModel>(s)).Single();
            }
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var reservation = _databaseContext.Reservations.Find(id);
                _databaseContext.Remove(reservation);
                _databaseContext.SaveChanges();
                
                _flashMessage.Confirmation(Translations.DeleteSuccess);
            }
            catch 
            {
                _flashMessage.Confirmation(Translations.DeleteFail);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Manage(ReservationsManageViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            try
            {
                Reservation reservation;

                if (viewModel.Id == 0)
                {
                    reservation = new Reservation
                    {
                        Confirmed = false
                    };
                    _databaseContext.Add(reservation);
                }
                else
                {
                    reservation = _databaseContext.Reservations.Find(viewModel.Id);
                }

                _mapper.Map(viewModel, reservation);
                reservation.UserId = 2;

                _databaseContext.SaveChanges();

                if (viewModel.Id == 0)
                    _flashMessage.Confirmation(Translations.ReservationAddSuccess);
                else
                    _flashMessage.Confirmation(Translations.ReservationEditSuccess);
            }
            catch
            {
                if (viewModel.Id == 0)
                    _flashMessage.Danger(Translations.ReservationAddFailure);
                else
                    _flashMessage.Danger(Translations.ReservationEditFailure);
            }

            return RedirectToAction("Index");
        }
    }
}
