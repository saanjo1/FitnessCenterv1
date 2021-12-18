namespace FitnessCenter.Data.Entities
{
    public class Goal : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int GoalTypeId { get; set; }
        public GoalType GoalType { get; set; }

        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public string Value { get; set; }

        public bool Completed { get; set; }
    }
}
