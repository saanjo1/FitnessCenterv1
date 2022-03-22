namespace FitnessCenter.Data.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
        public double? ServicePrice { get; set; }
        public int NotificationNumber { get; set; }

        public ICollection<Announcement> UserAnnouncements { get; set; } //userId
        public ICollection<Announcement> AuthorAnnouncements { get; set; } //authorId
        public ICollection<Contact> Contacts { get; set; } //contact
        public ICollection<Equipment> Equipment { get; set; } //equipment
        public ICollection<Event> Events { get; set; } //Event
        public ICollection<GoalType> GoalTypes { get; set; } //GoalType
        public ICollection<Goal> Goals { get; set; } //Goals
        public ICollection<Sponsor> Sponsors { get; set; } //Sponsor
        public ICollection<UserSupplement> UserSupplements { get; set; } //UserSupplement
        public ICollection<UserSubscription> UserSubscriptions { get; set; } //UserSubscription
        public ICollection<Reservation> UserReservations { get; set; } //UserReservation
        public ICollection<Reservation> CoachReservations { get; set; } //CoachReservation
    }
}
