namespace FitnessCenter.Data.Entities
{
    public class Workout : BaseEntity
    {
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }

        public int UserSubscriptionId { get; set; }
        public UserSubscription UserSubscription { get; set; }
    }
}
