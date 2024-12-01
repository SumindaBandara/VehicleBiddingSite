using BidNest.Models;
using Microsoft.EntityFrameworkCore;

namespace BidNest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Define tables
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Bidder> Bids { get; set; }
        public DbSet<Payment> Payments { get; set; }
        

        // Define relationships and configure entities
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.ClerkUserId);
                entity.Property(e => e.ClerkUserId).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();

                entity.HasMany(u => u.Items)
                    .WithOne(i => i.Seller)
                    .HasForeignKey(i => i.SellerId);

                entity.HasMany(u => u.Bid)
                    .WithOne(b => b.Bidder)
                    .HasForeignKey(b => b.BidderId);
            });

            // Configure Item entity
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasMany(i => i.Bids)
                    .WithOne(b => b.Item)
                    .HasForeignKey(b => b.ItemId);
            });

            // Configure Bid entity
            modelBuilder.Entity<Bidder>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            // Configure Payment entity
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            
        }
    }
}
