﻿// <auto-generated />
using System;
using FitnessCenter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessCenter.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220104234207_SponsorUpdate")]
    partial class SponsorUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FitnessCenter.Data.Entities.Announcement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("UserId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.HasIndex("UserId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.HasIndex("UserId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Excercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Excercises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Private"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Functional"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Full body"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Focus gluteus"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Pilates"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Zumba"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Core and cardio"
                        });
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.FitnessRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OpenFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("OpenTo")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("FitnessRooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Functional room",
                            Price = 20.0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cardio room",
                            Price = 25.0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pilates room",
                            Price = 30.0
                        },
                        new
                        {
                            Id = 4,
                            Name = "Private trainings room",
                            Price = 50.0
                        });
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateTimeFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("GoalTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GoalTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.GoalType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("GoalTypes");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CoachId")
                        .HasColumnType("int");

                    b.Property<bool>("Confirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateTimeFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("FitnessRoomId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("FitnessRoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.ReservationSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ExcerciseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkingDay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExcerciseId");

                    b.HasIndex("ReservationId");

                    b.ToTable("ReservationSchedules");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Sponsor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.HasIndex("UserId");

                    b.ToTable("Sponsors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description",
                            Name = "Proteini.si",
                            PhotoId = 0,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("WorkoutLimit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Supplement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("SponsorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.HasIndex("SponsorId");

                    b.ToTable("Supplements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Whey protein description",
                            Name = "Whey protein (1kg)",
                            PhotoId = 0,
                            Price = 40.0,
                            SponsorId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Creatine description",
                            Name = "Creatine 200mg",
                            PhotoId = 0,
                            Price = 25.0,
                            SponsorId = 1
                        });
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<double?>("ServicePrice")
                        .HasColumnType("float");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@admin",
                            FirstName = "admin",
                            LastName = "admin",
                            PasswordHash = "yVKb7CTcH+6eS7Y+Xzhp4Us8FK5sHv4Tt5ZBDfTcuoU=",
                            PasswordSalt = "ZNWv2EKaW8VNB6ZjXUAevw==",
                            Role = 0,
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "muhamed.brkan@edu.fit.ba",
                            FirstName = "Muhamed",
                            LastName = "Brkan",
                            PasswordHash = "yVKb7CTcH+6eS7Y+Xzhp4Us8FK5sHv4Tt5ZBDfTcuoU=",
                            PasswordSalt = "ZNWv2EKaW8VNB6ZjXUAevw==",
                            Role = 2,
                            Username = "muhamed.brkan"
                        },
                        new
                        {
                            Id = 3,
                            Email = "sanjin.golos@edu.fit.ba",
                            FirstName = "Sanjin",
                            LastName = "Gološ",
                            PasswordHash = "yVKb7CTcH+6eS7Y+Xzhp4Us8FK5sHv4Tt5ZBDfTcuoU=",
                            PasswordSalt = "ZNWv2EKaW8VNB6ZjXUAevw==",
                            Role = 1,
                            Username = "sanjin.golos"
                        },
                        new
                        {
                            Id = 4,
                            Email = "adil@edu.fit.ba",
                            FirstName = "Adil",
                            LastName = "Joldić",
                            PasswordHash = "yVKb7CTcH+6eS7Y+Xzhp4Us8FK5sHv4Tt5ZBDfTcuoU=",
                            PasswordSalt = "ZNWv2EKaW8VNB6ZjXUAevw==",
                            Role = 1,
                            Username = "adil.joldic"
                        });
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.UserSubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateTimeFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeTo")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSubscriptions");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.UserSupplement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SupplementId")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiscountId");

                    b.HasIndex("SupplementId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSupplements");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateTimeFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserSubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserSubscriptionId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Announcement", b =>
                {
                    b.HasOne("FitnessCenter.Data.Entities.User", "Author")
                        .WithMany("AuthorAnnouncements")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FitnessCenter.Data.Entities.User", "User")
                        .WithMany("UserAnnouncements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Contact", b =>
                {
                    b.HasOne("FitnessCenter.Data.Entities.User", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Discount", b =>
                {
                    b.HasOne("FitnessCenter.Data.Entities.Photo", "Photo")
                        .WithMany("Discount")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Photo");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Equipment", b =>
                {
                    b.HasOne("FitnessCenter.Data.Entities.Photo", "Photo")
                        .WithMany("Equipment")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FitnessCenter.Data.Entities.User", "User")
                        .WithMany("Equipment")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Photo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Event", b =>
                {
                    b.HasOne("FitnessCenter.Data.Entities.Photo", "Photo")
                        .WithMany("Events")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FitnessCenter.Data.Entities.User", "User")
                        .WithMany("Events")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Photo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Goal", b =>
                {
                    b.HasOne("FitnessCenter.Data.Entities.GoalType", "GoalType")
                        .WithMany("Goals")
                        .HasForeignKey("GoalTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FitnessCenter.Data.Entities.User", "User")
                        .WithMany("Goals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GoalType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.GoalType", b =>
                {
                    b.HasOne("FitnessCenter.Data.Entities.User", "User")
                        .WithMany("GoalTypes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Reservation", b =>
                {
                    b.HasOne("FitnessCenter.Data.Entities.User", "Coach")
                        .WithMany("CoachReservations")
                        .HasForeignKey("CoachId");

                    b.HasOne("FitnessCenter.Data.Entities.FitnessRoom", "FitnessRoom")
                        .WithMany("Reservations")
                        .HasForeignKey("FitnessRoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FitnessCenter.Data.Entities.User", "User")
                        .WithMany("UserReservations")
                        .HasForeignKey("UserId");

                    b.Navigation("Coach");

                    b.Navigation("FitnessRoom");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.ReservationSchedule", b =>
                {
                    b.HasOne("FitnessCenter.Data.Entities.Excercise", "Excercise")
                        .WithMany("ReservationSchedules")
                        .HasForeignKey("ExcerciseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FitnessCenter.Data.Entities.Reservation", "Reservation")
                        .WithMany("ReservationSchedules")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Excercise");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Sponsor", b =>
                {
                    b.HasOne("FitnessCenter.Data.Entities.Photo", "Photo")
                        .WithMany("Sponsors")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FitnessCenter.Data.Entities.User", "User")
                        .WithMany("Sponsors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Photo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Supplement", b =>
                {
                    b.HasOne("FitnessCenter.Data.Entities.Photo", "Photo")
                        .WithMany("Supplements")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FitnessCenter.Data.Entities.Sponsor", "Sponsor")
                        .WithMany("Supplements")
                        .HasForeignKey("SponsorId");

                    b.Navigation("Photo");

                    b.Navigation("Sponsor");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.UserSubscription", b =>
                {
                    b.HasOne("FitnessCenter.Data.Entities.Subscription", "Subscription")
                        .WithMany("UserSubscriptions")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FitnessCenter.Data.Entities.User", "User")
                        .WithMany("UserSubscriptions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Subscription");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.UserSupplement", b =>
                {
                    b.HasOne("FitnessCenter.Data.Entities.Discount", "Discount")
                        .WithMany("UserSupplements")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FitnessCenter.Data.Entities.Supplement", "Supplement")
                        .WithMany("UserSupplements")
                        .HasForeignKey("SupplementId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FitnessCenter.Data.Entities.User", "User")
                        .WithMany("UserSupplements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Discount");

                    b.Navigation("Supplement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Workout", b =>
                {
                    b.HasOne("FitnessCenter.Data.Entities.UserSubscription", "UserSubscription")
                        .WithMany("Workouts")
                        .HasForeignKey("UserSubscriptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UserSubscription");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Discount", b =>
                {
                    b.Navigation("UserSupplements");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Excercise", b =>
                {
                    b.Navigation("ReservationSchedules");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.FitnessRoom", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.GoalType", b =>
                {
                    b.Navigation("Goals");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Photo", b =>
                {
                    b.Navigation("Discount");

                    b.Navigation("Equipment");

                    b.Navigation("Events");

                    b.Navigation("Sponsors");

                    b.Navigation("Supplements");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Reservation", b =>
                {
                    b.Navigation("ReservationSchedules");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Sponsor", b =>
                {
                    b.Navigation("Supplements");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Subscription", b =>
                {
                    b.Navigation("UserSubscriptions");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.Supplement", b =>
                {
                    b.Navigation("UserSupplements");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.User", b =>
                {
                    b.Navigation("AuthorAnnouncements");

                    b.Navigation("CoachReservations");

                    b.Navigation("Contacts");

                    b.Navigation("Equipment");

                    b.Navigation("Events");

                    b.Navigation("GoalTypes");

                    b.Navigation("Goals");

                    b.Navigation("Sponsors");

                    b.Navigation("UserAnnouncements");

                    b.Navigation("UserReservations");

                    b.Navigation("UserSubscriptions");

                    b.Navigation("UserSupplements");
                });

            modelBuilder.Entity("FitnessCenter.Data.Entities.UserSubscription", b =>
                {
                    b.Navigation("Workouts");
                });
#pragma warning restore 612, 618
        }
    }
}
