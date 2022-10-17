using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookMyFlight.Models
{
    public partial class BookMyFlightContext : DbContext
    {
        public BookMyFlightContext()
        {
        }

        public BookMyFlightContext(DbContextOptions<BookMyFlightContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AvailableFlight> AvailableFlights { get; set; } = null!;
        public virtual DbSet<FlightBooking> FlightBookings { get; set; } = null!;
        public virtual DbSet<FlightDetail> FlightDetails { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<UserDatum> UserData { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=BookMyFlight;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvailableFlight>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK_sno");

                entity.ToTable("AvailableFlight");

                entity.Property(e => e.Sno)
                    .ValueGeneratedNever()
                    .HasColumnName("sno");

                entity.Property(e => e.Class)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DepartureDate).HasColumnType("datetime");

                entity.Property(e => e.FromWhere)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.WhereTo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlightBooking>(entity =>
            {
                entity.HasKey(e => e.Passengername)
                    .HasName("PK_passengername");

                entity.ToTable("FlightBooking");

                entity.Property(e => e.Passengername)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("passengername");

                entity.Property(e => e.Arrival)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("arrival");

                entity.Property(e => e.ArrivalTime)
                    .HasColumnType("time(3)")
                    .HasColumnName("arrivalTime");

                entity.Property(e => e.Class)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("class");

                entity.Property(e => e.Departure)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("departure");

                entity.Property(e => e.TravelDate)
                    .HasColumnType("date")
                    .HasColumnName("travelDate");
            });

            modelBuilder.Entity<FlightDetail>(entity =>
            {
                entity.HasKey(e => e.FromWhere)
                    .HasName("PK_FromWhere");

                entity.ToTable("FlightDetail");

                entity.Property(e => e.FromWhere)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Class)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DepartureDate).HasColumnType("date");

                entity.Property(e => e.WhereTo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK_Pid");

                entity.ToTable("Payment");

                entity.Property(e => e.Pid).ValueGeneratedNever();

                entity.Property(e => e.Cvv).HasColumnName("cvv");

                entity.Property(e => e.ExpDate).HasColumnType("date");

                entity.Property(e => e.NameonCard)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserDatum>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK_email");

                entity.Property(e => e.Email)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.Password)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phonenumber).HasColumnName("phonenumber");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
