using FitnessCenter.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessCenter.Web.ViewModels
{
    public class ReservationIndexViewModel
    {
        public List<Reservation> reservations { get; set; }
    }
}
