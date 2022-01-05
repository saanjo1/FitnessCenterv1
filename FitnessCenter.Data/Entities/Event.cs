namespace FitnessCenter.Data.Entities
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public string About { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public int? Rate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}
