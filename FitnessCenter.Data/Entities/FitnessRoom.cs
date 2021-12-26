namespace FitnessCenter.Data.Entities
{
    public class FitnessRoom : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime? OpenFrom { get; set; }
        public DateTime? OpenTo { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
