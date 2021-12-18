namespace FitnessCenter.Data.Entities
{
    public class Excercise : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<ReservationSchedule> ReservationSchedules { get; set; }
    }
}
