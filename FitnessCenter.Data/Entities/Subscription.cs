namespace FitnessCenter.Data.Entities
{
    public class Subscription : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int WorkoutLimit { get; set; }

        public ICollection<UserSubscription> UserSubscriptions { get; set; }
    }
}
