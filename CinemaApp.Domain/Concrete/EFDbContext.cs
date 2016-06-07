using CinemaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Concrete
{

    // NOTE: For each new entity, you can remove the comment for the entity.
    [ExcludeFromCodeCoverage]
    public class EFDbContext : DbContext
    {
        public EFDbContext() {
       //    Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Enquette> Enquettes { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Hall> Halls { get; set; }
        public DbSet<Kijkwijzer> Kijkwijzers { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Rate> Rates { get; set; }

        public DbSet<Row> Rows { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Chair> Chairs { get; set; }

        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Row>()
                .HasRequired(c => c.HallID)
                .WithMany()
                .WillCascadeOnDelete(false);
                

            modelBuilder.Entity<Seat>()
                .HasRequired(c => c.HallID)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Seat>()
                .HasRequired(c => c.RowID)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chair>()
                .HasRequired(c => c.SeatID)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chair>()
                .HasRequired(c => c.ScheduleID)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasRequired(c => c.Schedule)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Schedule>()
                .HasRequired(c => c.movie)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Schedule>()
                .HasRequired(c => c.hall)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasRequired(c => c.ticketHall)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasRequired(c => c.ticketMovie)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasRequired(c => c.ticketRate)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasRequired(c => c.ticketRow)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasRequired(c => c.ticketSchedule)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasRequired(c => c.ticketSeat)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hall>()
                .HasRequired(c => c.CinemaID)
                .WithMany()
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
