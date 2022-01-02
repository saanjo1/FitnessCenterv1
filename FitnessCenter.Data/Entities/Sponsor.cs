namespace FitnessCenter.Data.Entities
{
    public class Sponsor : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PhotoId { get; set; }
        public Photo Photo { get; set; }

        public ICollection<Supplement> Supplements { get; set; }
    }
}
