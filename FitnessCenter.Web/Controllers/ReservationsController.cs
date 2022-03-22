using AutoMapper;
using FitnessCenter.Data;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.Hubs;
using FitnessCenter.Web.Resources;
using FitnessCenter.Web.Utilities.Constants;
using FitnessCenter.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Vereyon.Web;

namespace FitnessCenter.Web.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFlashMessage _flashMessage;
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager _userManager;
        private IHubContext<MyHub> _hubContext;

        public ReservationsController(IMapper mapper, IHubContext<MyHub> hubContext, IFlashMessage flashMessage, DatabaseContext databaseContext,UserManager userManager)
        {
            _mapper = mapper;
            _flashMessage = flashMessage;
            _databaseContext = databaseContext;
            _userManager = userManager;
            _hubContext = hubContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userId = _userManager.Get().Id;
           
            var reservationsQuery = _databaseContext.Reservations
                 .Include(r => r.FitnessRoom)
                 .Include(r => r.User)
                 .Include(r => r.Coach)
                 .AsQueryable();

            if (_userManager.IsInRoles(Role.Client, Role.Coach))
            {
                reservationsQuery = reservationsQuery
                    .Where(r => r.UserId == userId || r.CoachId == userId);
            }
            var resevarions = reservationsQuery.ToList();

            return View(new ReservationsIndexViewModel
            {
                Reservations = resevarions
            });
        }
        [HttpGet]
        [ActionName("change_status")]
        public IActionResult Confirm(int id)
        {
            var viewModel = new ReservationsConfirmViewModel
            {
                Confirmed = _databaseContext.Reservations.Where(r => r.Id == id).Single().Confirmed,
                Id = id
            };

            return PartialView("Confirm", viewModel);

        }

        [HttpPost]
        [ActionName("change_status")]
        public IActionResult Confirm(ReservationsConfirmViewModel m)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");
            try
            {
                Reservation reservation = _databaseContext.Reservations.Find(m.Id);
                reservation.Confirmed = m.Confirmed;

                _databaseContext.Reservations.Update(reservation);
                _databaseContext.SaveChanges();
                SendMessage("changed", reservation.UserId);

                var user = _databaseContext.Users.Where(x => x.Id == reservation.UserId).FirstOrDefault();
                user.NotificationNumber = ++user.NotificationNumber;

                _databaseContext.Update(user);
                _databaseContext.SaveChanges();



                _flashMessage.Confirmation(Translations.ConfirmReservationSuccess);
            }
            catch
            {
                _flashMessage.Danger(Translations.ConfirmReservationFailure);
            }

            return RedirectToAction("Index");

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
                    DateTimeTo = DateTime.Now,
                    UserId = _userManager.Get().Id
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
                        Confirmed = false,
                    };
                    _databaseContext.Add(reservation);
                }
                else
                {
                    reservation = _databaseContext.Reservations.Find(viewModel.Id);
                }
                _mapper.Map(viewModel, reservation);

                _databaseContext.SaveChanges();
                SendMessage("added", null);

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

        public IActionResult ResetAdminCounter(int id)
        {
            var users = _databaseContext.Users.Where(x => x.Role == Role.Administrator || x.Role == Role.Coach).ToList();

            foreach(var user in users)
            {
                user.NotificationNumber = 0;
                _databaseContext.Update(user);
            }

            _databaseContext.SaveChanges();

            return Redirect("Index");
        }

        public IActionResult ResetCounter(int id)
        {
            var user = _databaseContext.Users.Where(i => i.Id == id).FirstOrDefault();

            user.NotificationNumber = 0;
            _databaseContext.Update(user);
            _databaseContext.SaveChanges();

            return RedirectToAction("Index");
        }

        private void SendMessage(string message, int? id)
        {
            if (id.HasValue)
            {
                var user = _databaseContext.Users.Where(x => x.Id == id).FirstOrDefault();

                if (user == null)
                    _hubContext.Clients.All.SendAsync("RecieveNotification", message);
                else
                    _hubContext.Clients.All.SendAsync("RecieveNotification", message, user.Id);
            }
            else
            {
                _hubContext.Clients.All.SendAsync("RecieveNotification", message);
            }
        }
    }
}
