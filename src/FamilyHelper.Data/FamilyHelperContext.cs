using FamilyHelper.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamilyHelper.Data
{
    public class FamilyHelperContext : DbContext
    {
        public DbSet<Family> Families { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Family>()
                .Property(f => f.FamilyName)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.HashedPassword)
                .HasMaxLength(450)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasOne(u => u.Family)
                .WithMany(f => f.Users)
                .HasForeignKey(u => u.FamilyId);
        }
    }
}
