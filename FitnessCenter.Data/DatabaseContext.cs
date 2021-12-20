using FitnessCenter.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Excercise> Excercises { get; set; }
        public DbSet<FitnessRoom> FitnessRooms { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<GoalType> GoalTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationSchedule> ReservationSchedules { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }
        public DbSet<UserSupplement> UserSupplements { get; set; }
        public DbSet<Workout> Workouts { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        FirstName = "admin",
                        LastName = "admin",
                        Username = "admin",
                        Email = "admin@admin",
                        Role = Role.Administrator,
                        PasswordSalt = "admin",
                        PasswordHash = "admin"
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "Muhamed",
                        LastName = "Brkan",
                        Username = "muhamed.brkan",
                        Email = "muhamed.brkan@edu.fit.ba",
                        Role = Role.Client,
                        PasswordSalt = "_",
                        PasswordHash = "_"
                    },
                     new User
                     {
                         Id = 3,
                         FirstName = "Sanjin",
                         LastName = "Gološ",
                         Username = "sanjin.golos",
                         Email = "sanjin.golos@edu.fit.ba",
                         Role = Role.Coach,
                         PasswordSalt = "_",
                         PasswordHash = "_",
                     }
                );

            modelBuilder.Entity<Announcement>()
                .HasOne<User>(a => a.Author)
                .WithMany(a => a.AuthorAnnouncements)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Announcement>()
               .HasOne<User>(a => a.User)
               .WithMany(u => u.UserAnnouncements)
               .HasForeignKey(a => a.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne<User>(r => r.Coach)
                .WithMany(c => c.CoachReservations)
                .HasForeignKey(r => r.CoachId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
               .HasOne<User>(r => r.User)
               .WithMany(u => u.UserReservations)
               .HasForeignKey(r => r.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Goal>()
               .HasOne<User>(g => g.User)
               .WithMany(u => u.Goals)
               .HasForeignKey(g => g.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GoalType>()
               .HasOne<User>(gt => gt.User)
               .WithMany(u => u.GoalTypes)
               .HasForeignKey(gt => gt.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}