using FamilyHelper.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FamilyHelper.Data
{
    public class FamilyHelperContext : IdentityDbContext<User, IdentityRole<long>, long>
    {
        public DbSet<Family> Families { get; set; }

        public FamilyHelperContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Family>()
                .Property(f => f.Id)
                .HasColumnName("family_id");

            modelBuilder.Entity<Family>()
                .Property(f => f.FamilyName)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Family>()
                .HasIndex(f => f.FamilyName)
                .IsUnique();

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
                .Property(u => u.PasswordHash)
                .HasMaxLength(450)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasOne(u => u.Family)
                .WithMany(f => f.Users)
                .HasForeignKey(u => u.FamilyId);
        }
    }
}
