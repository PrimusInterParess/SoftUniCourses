using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace _01Demo.Models
{
    public partial class ColonialJourneyContext : DbContext
    {
        public ColonialJourneyContext()
        {
        }

        public ColonialJourneyContext(DbContextOptions<ColonialJourneyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountsTrip> AccountsTrips { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Colonist> Colonists { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Journey> Journeys { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Spaceport> Spaceports { get; set; }
        public virtual DbSet<Spaceship> Spaceships { get; set; }
        public virtual DbSet<TravelCard> TravelCards { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Integrated Security=true;Database=ColonialJourney");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Accounts__A9D105348BC0E805")
                    .IsUnique();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(20);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Accounts__CityId__6383C8BA");
            });

            modelBuilder.Entity<AccountsTrip>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.TripId })
                    .HasName("PK_Account_Trip");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountsTrips)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AccountsT__Accou__66603565");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.AccountsTrips)
                    .HasForeignKey(d => d.TripId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AccountsT__TripI__6754599E");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Colonist>(entity =>
            {
                entity.HasIndex(e => e.Ucn, "UQ__Colonist__C5B68A1A7CB98E2E")
                    .IsUnique();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ucn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.BaseRate).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Hotels__CityId__5812160E");
            });

            modelBuilder.Entity<Journey>(entity =>
            {
                entity.Property(e => e.JourneyEnd).HasColumnType("datetime");

                entity.Property(e => e.JourneyStart).HasColumnType("datetime");

                entity.Property(e => e.Purpose)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.DestinationSpaceport)
                    .WithMany(p => p.Journeys)
                    .HasForeignKey(d => d.DestinationSpaceportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Journeys__Destin__3D5E1FD2");

                entity.HasOne(d => d.Spaceship)
                    .WithMany(p => p.Journeys)
                    .HasForeignKey(d => d.SpaceshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Journeys__Spaces__3E52440B");
            });

            modelBuilder.Entity<Planet>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rooms__HotelId__5AEE82B9");
            });

            modelBuilder.Entity<Spaceport>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Planet)
                    .WithMany(p => p.Spaceports)
                    .HasForeignKey(d => d.PlanetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Spaceport__Plane__267ABA7A");
            });

            modelBuilder.Entity<Spaceship>(entity =>
            {
                entity.Property(e => e.LightSpeedRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TravelCard>(entity =>
            {
                entity.HasIndex(e => e.CardNumber, "UQ__TravelCa__A4E9FFE9F4B9E85A")
                    .IsUnique();

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.JobDuringJourney)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.Colonist)
                    .WithMany(p => p.TravelCards)
                    .HasForeignKey(d => d.ColonistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TravelCar__Colon__5070F446");

                entity.HasOne(d => d.Journey)
                    .WithMany(p => p.TravelCards)
                    .HasForeignKey(d => d.JourneyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TravelCar__Journ__5165187F");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.Property(e => e.ArrivalDate).HasColumnType("date");

                entity.Property(e => e.BookDate).HasColumnType("date");

                entity.Property(e => e.CancelDate).HasColumnType("date");

                entity.Property(e => e.ReturnDate).HasColumnType("date");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trips__RoomId__5DCAEF64");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
