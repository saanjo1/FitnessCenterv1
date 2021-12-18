namespace FitnessCenter.Data.Entities
{
    public class Reservation : BaseEntity
    {
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public bool Confirmed { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int CoachId { get; set; }
        public User Coach { get; set; }
        public int FitnessRoomId { get; set; }
        public FitnessRoom FitnessRoom { get; set; }

        public ICollection<ReservationSchedule> ReservationSchedules { get; set; }
    }
}
