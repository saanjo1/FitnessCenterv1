using FitnessCenter.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessCenter.Web.ViewModels
{
    public class ReservationsCreateViewModel
    {
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }

        public int UserId { get; set; }
        public int CoachId  { get; set; }
        public int FitnessRoomId { get; set; }


        public List<SelectListItem> Coaches { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<SelectListItem> FitnessRooms { get; set; }
    }
}
