namespace FitnessCenter.Data.Entities
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
