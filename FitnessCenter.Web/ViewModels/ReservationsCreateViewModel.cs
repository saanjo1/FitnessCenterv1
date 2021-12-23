using FitnessCenter.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessCenter.Web.ViewModels
{
    public class ReservationsCreateViewModel
    {

        public int Id { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public bool Confirmed { get; set; }


        public List<Reservation> reservations { get; set; }
        public int? UserId { get; set; }
        public List<SelectListItem> Users { get; set; }
        public int? CoachId { get; set; }
        public List<SelectListItem> Coaches { get; set; }
        public int FitnessRoomId { get; set; }
        public List<SelectListItem> FitnessRooms { get; set; }

    }
}
