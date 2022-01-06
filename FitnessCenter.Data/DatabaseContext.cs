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
        public DbSet<Photo> Photo { get; set; }


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
                        PasswordSalt = "ZNWv2EKaW8VNB6ZjXUAevw==",
                        PasswordHash = "yVKb7CTcH+6eS7Y+Xzhp4Us8FK5sHv4Tt5ZBDfTcuoU="
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "Muhamed",
                        LastName = "Brkan",
                        Username = "muhamed.brkan",
                        Email = "muhamed.brkan@edu.fit.ba",
                        Role = Role.Client,
                        PasswordSalt = "ZNWv2EKaW8VNB6ZjXUAevw==",
                        PasswordHash = "yVKb7CTcH+6eS7Y+Xzhp4Us8FK5sHv4Tt5ZBDfTcuoU="
                    },
                     new User
                     {
                         Id = 3,
                         FirstName = "Sanjin",
                         LastName = "Gološ",
                         Username = "sanjin.golos",
                         Email = "sanjin.golos@edu.fit.ba",
                         Role = Role.Coach,
                         PasswordSalt = "ZNWv2EKaW8VNB6ZjXUAevw==",
                         PasswordHash = "yVKb7CTcH+6eS7Y+Xzhp4Us8FK5sHv4Tt5ZBDfTcuoU=",
                     },
                       new User
                       {
                           Id = 4,
                           FirstName = "Adil",
                           LastName = "Joldić",
                           Username = "adil.joldic",
                           Email = "adil@edu.fit.ba",
                           Role = Role.Coach,
                           PasswordSalt = "ZNWv2EKaW8VNB6ZjXUAevw==",
                           PasswordHash = "yVKb7CTcH+6eS7Y+Xzhp4Us8FK5sHv4Tt5ZBDfTcuoU=",
                       }
                );

            modelBuilder.Entity<Excercise>()
               .HasData(
                    new Excercise
                    {
                        Id = 1,
                        Name = "Private"
                    },
                    new Excercise
                    {
                        Id = 2,
                        Name = "Functional"
                    },
                    new Excercise
                    {
                        Id = 3,
                        Name = "Full body"
                    },
                    new Excercise
                    {
                        Id = 4,
                        Name = "Focus gluteus"
                    },
                    new Excercise
                    {
                        Id = 5,
                        Name = "Pilates"
                    },
                    new Excercise
                    {
                        Id = 6,
                        Name = "Zumba"
                    },
                    new Excercise
                    {
                        Id = 7,
                        Name = "Core and cardio"
                    }
                );

            modelBuilder.Entity<FitnessRoom>()
              .HasData(
                new FitnessRoom
                {
                    Id = 1,
                    Name = "Functional room",
                    Price = 20.00,
                },
                new FitnessRoom
                {
                    Id = 2,
                    Name = "Cardio room",
                    Price = 25.00,
                },
                new FitnessRoom
                {
                    Id = 3,
                    Name = "Pilates room",
                    Price = 30.00,
                },
                new FitnessRoom
                {
                    Id = 4,
                    Name = "Private trainings room",
                    Price = 50.00,
                }
            );

            modelBuilder.Entity<Sponsor>()
              .HasData(
                new Sponsor
                {
                    Id = 1,
                    Name = "Proteini.si",
                    Description = "Description",
                    UserId = 2
                });

            modelBuilder.Entity<Supplement>()
              .HasData(
                new Supplement
                {
                    Id = 1,
                    SponsorId = 1,
                    Name = "Whey protein (1kg)",
                    Description = "Whey protein description",
                    Price = 40.00,
                },
                new Supplement
                {
                    Id = 2,
                    SponsorId = 1,
                    Name = "Creatine 200mg",
                    Description = "Creatine description",
                    Price = 25.00,
                });

            modelBuilder.Entity<Announcement>()
              .HasData(
                new Announcement
                {
                    Id = 1,
                    AuthorId = 1,
                    Title = "Free weekend",
                    Description = "Free weekend for all clients",
                    UserId = 3
                });


            modelBuilder.Entity<Announcement>()
               .HasOne(a => a.Author)
               .WithMany(a => a.AuthorAnnouncements)
               .HasForeignKey(a => a.AuthorId);

            modelBuilder.Entity<Announcement>()
               .HasOne(a => a.User)
               .WithMany(u => u.UserAnnouncements)
               .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<Reservation>()
               .HasOne(r => r.Coach)
               .WithMany(c => c.CoachReservations)
               .HasForeignKey(r => r.CoachId);

            modelBuilder.Entity<Reservation>()
               .HasOne(r => r.User)
               .WithMany(u => u.UserReservations)
               .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Goal>()
               .HasOne(g => g.User)
               .WithMany(u => u.Goals)
               .HasForeignKey(g => g.UserId);

            modelBuilder.Entity<GoalType>()
               .HasOne(gt => gt.User)
               .WithMany(u => u.GoalTypes)
               .HasForeignKey(gt => gt.UserId);

            modelBuilder.Entity<UserSupplement>()
               .HasOne(us => us.User)
               .WithMany(u => u.UserSupplements)
               .HasForeignKey(us => us.UserId);

            modelBuilder.Entity<UserSupplement>()
               .HasOne(us => us.Supplement)
               .WithMany(s => s.UserSupplements)
               .HasForeignKey(us => us.SupplementId);

            var foreignKeys = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in foreignKeys)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            
            base.OnModelCreating(modelBuilder);
        }
    }
}