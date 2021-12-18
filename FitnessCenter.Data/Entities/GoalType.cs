namespace FitnessCenter.Data.Entities
{
    public class GoalType : BaseEntity
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Goal> Goals { get; set; }
    }
}
