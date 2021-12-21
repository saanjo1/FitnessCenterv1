namespace FitnessCenter.Data.Entities
{
    public class FitnessRoom : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime? ReservedFrom { get; set; }
        public DateTime? ReservedTo { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
