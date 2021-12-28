namespace FitnessCenter.Data.Entities
{
    public class Supplement : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public int SponsorId { get; set; }
        public Sponsor Sponsor { get; set; }

        public ICollection<UserSupplement> UserSupplements { get; set; }
    }
}
