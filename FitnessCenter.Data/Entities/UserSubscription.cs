namespace FitnessCenter.Data.Entities
{
    public class UserSubscription : BaseEntity
    {
        public double Price { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        public ICollection<Workout> Workouts { get; set; }
    }
}
