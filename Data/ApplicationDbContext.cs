using Microsoft.EntityFrameworkCore;
using FlixHub.Models;

namespace FlixHub.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(

                new User
                {
                    Id = 1,
                    Email = "admin123@gmail.com",
                    Password = "admin123",
                    ConfirmPassword = "admin123",
                    Name = "Muthukumar",
                    Contact = 7806955525,
                    Role = "Admin"
                });
            modelBuilder.Entity<User>().Property(p => p.Role).HasDefaultValue("User");

            //modelBuilder.Entity<Booking>().Property(p => p.BookingDate).HasDefaultValue(DateTime.Now);


            //modelBuilder.Entity<Booking>()
            //    .HasOne(b => b.User)
            //    .WithMany(u => u.Bookings)
            //    .HasForeignKey(b => b.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            // Movie to Booking relationship
            //modelBuilder.Entity<Booking>()
            //    .HasOne(b => b.Movie)
            //    .WithMany(m => m.Bookings)
            //    .HasForeignKey(b => b.MovieId)
            //    .OnDelete(DeleteBehavior.Cascade);

            // Theatre to Booking relationship
            //modelBuilder.Entity<Booking>()
            //    .HasOne(b => b.Theatre)
            //    .WithMany(t => t.Bookings)
            //    .HasForeignKey(b => b.TheatreId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}