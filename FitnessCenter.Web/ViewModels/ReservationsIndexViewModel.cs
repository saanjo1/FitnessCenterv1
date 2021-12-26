using FitnessCenter.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessCenter.Web.ViewModels
{
    public class ReservationsIndexViewModel
    {
        public List<Reservation> Reservations { get; set; }
    }
}
