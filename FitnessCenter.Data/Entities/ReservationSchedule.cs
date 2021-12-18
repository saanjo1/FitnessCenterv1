namespace FitnessCenter.Data.Entities
{
    public class ReservationSchedule : BaseEntity
    {
        public int WorkingDay { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public int ExcerciseId { get; set; }
        public Excercise Excercise { get; set; }
    }
}
