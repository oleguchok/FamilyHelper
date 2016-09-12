using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FamilyHelper.Data;

namespace FamilyHelper.Data.Migrations
{
    [DbContext(typeof(FamilyHelperContext))]
    partial class FamilyHelperContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FamilyHelper.Entities.Entities.Family", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("family_id");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 150);

                    b.HasKey("Id");

                    b.HasIndex("FamilyName")
                        .IsUnique();

                    b.ToTable("Families");
                });

            modelBuilder.Entity("FamilyHelper.Entities.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<long>("FamilyId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 450);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 150);

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FamilyHelper.Entities.Entities.User", b =>
                {
                    b.HasOne("FamilyHelper.Entities.Entities.Family", "Family")
                        .WithMany("Users")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
