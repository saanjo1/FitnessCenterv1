namespace FitnessCenter.Data.Entities
{
    public class Equipment : BaseEntity
    {
        public string Name { get; set; }
        public byte[] Photo { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
