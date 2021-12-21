using FitnessCenter.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessCenter.Web.ViewModels
{
    public class ReservationsCreateViewModel
    {
            public DateTime DateTimeFrom { get; set; }
            public DateTime DateTimeTo { get; set; }
            public double TotalPrice { get; set; }
            public int UserId { get; set; }


            public int FitnessRoomId { get; set; }
            public List<SelectListItem> FitnessRooms { get; set; }


    }
}
