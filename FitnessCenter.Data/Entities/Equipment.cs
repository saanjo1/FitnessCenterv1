namespace FitnessCenter.Data.Entities
{
    public class Equipment : BaseEntity
    {
        public string Name { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}
