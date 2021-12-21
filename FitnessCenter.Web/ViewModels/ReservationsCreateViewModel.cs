using FitnessCenter.Data.Entities;

namespace FitnessCenter.Web.ViewModels
{
    public class ReservationsCreateViewModel
    {
        public Reservation Reservation { get; set; }
        List<User> Users { get; set; }
        List<FitnessRoom> FitnessRooms { get; set; }
    }
}
